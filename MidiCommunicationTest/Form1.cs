using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiCommunicationTest
{
	public partial class Form1 : Form
	{
		MidiOut midiOut;
		MidiIn midiIn;

		string outPortName;
		string inPortName;

		delegate void PrintMidiDelegate(string msg);
		PrintMidiDelegate PrintMidi;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			button_MidiOutClose.BackColor = button_MidiInClose.BackColor = SystemColors.ControlDarkDark;

			PrintMidi = PrintMidiExe;
		}

		/// <summary>
		/// MIDI In テキストボックスに受信したMIDIメッセージを表示します。
		/// イベントから直接コールできません。デリゲートPrintMidiをInvokeしてください。
		/// </summary>
		/// <param name="msg"></param>
		void PrintMidiExe(string msg)
		{
			textBox_MidiIn.AppendText(msg + "\r\n");
		}

		/// <summary>
		/// テキストボックスに入力されたMIDIメッセージテキストをバイナリに変換します。
		/// テキストボックス内のスペース、コロン、カンマ、"0x"、改行コードは取り除かれます。
		/// </summary>
		/// <param name="midiText">バイナリに変換したい文字列</param>
		/// <returns>バイナリ返還されたデータ。16進数でない不正文字列や、奇数個の文字列だった場合はnullが返ります。/returns>
		byte[] Text2Bin(string midiText)
		{
			int i;
			string midiReplaced; //スペース、コロン、カンマ、"0x"、改行を取り除いた文字列
			byte[] midiByte;

			midiReplaced = midiText.Replace(" ", "");
			midiReplaced = midiReplaced.Replace(",", "");
			midiReplaced = midiReplaced.Replace(":", "");
			midiReplaced = midiReplaced.Replace("0x", "");
			midiReplaced = midiReplaced.Replace("\r", "");
			midiReplaced = midiReplaced.Replace("\n", "");

			if((midiReplaced.Length & 0x01) != 0) return null; //文字数が奇数個の場合は不適切なデータとして扱う

			midiByte = new byte[midiReplaced.Length/2];

			//2つの文字列を1つのバイトに集約
			for(i=0; i < midiByte.Length; i++)
			{
				int j = 2 * i;
				//奇数文字目
				if('0' <= midiReplaced[j] && midiReplaced[j] <= '9')
				{
					midiByte[i] = (byte)(((byte)midiReplaced[j] - '0') << 4);
				}
				else if('a' <= midiReplaced[j] && midiReplaced[j] <= 'f')
				{
					midiByte[i] = (byte)(((byte)midiReplaced[j] - 'a' + 0x0A) << 4);
				}
				else if('A' <= midiReplaced[j] && midiReplaced[j] <= 'F')
				{
					midiByte[i] = (byte)(((byte)midiReplaced[j] - 'A' + 0x0A) << 4);
				}
				else
				{
					return null; //16進数でない文字列
				}

				//偶数文字目
				j++;
				if ('0' <= midiReplaced[j] && midiReplaced[j] <= '9')
				{
					midiByte[i] |= (byte)((byte)midiReplaced[j] - '0');
				}
				else if ('a' <= midiReplaced[j] && midiReplaced[j] <= 'f')
				{
					midiByte[i] |= (byte)((byte)midiReplaced[j] - 'a' + 0x0A);
				}
				else if ('A' <= midiReplaced[j] && midiReplaced[j] <= 'F')
				{
					midiByte[i] |= (byte)((byte)midiReplaced[j] - 'A' + 0x0A);
				}
				else
				{
					return null; //16進数でない文字列
				}
			}

			return midiByte;
		}

		/// <summary>
		/// MIDI Outテキストボックス内に記載されたメッセージをバイナリに変換して送信します。
		/// </summary>
		void SendMidi()
		{
			byte[] midiByte = Text2Bin(textBox_MidiOut.Text);
			if(midiByte == null)
			{
				MessageBox.Show("入力値が不正です。\r\n16進数で偶数個の文字列で入力してください。",
					"入力値不正",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}

			midiOut.Send(midiByte);
		}

		/// <summary>
		/// MIDI Inのショートメッセージを受け取った時のイベントハンドラ
		/// まずはとりあえず表示だけさせてみる。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MidiInShortEvent(object sender, ReceivedMidiEventEventArgs e)
		{
			byte[] mData = new byte[3];

			mData[0] = (byte)((int)e.Event.Type | e.Event.Channel);
			mData[1] = (byte)e.Event.Data1;
			mData[2] = (byte)e.Event.Data2;

			/*
			switch((int)e.Event.Type)
			{
				case STATUSBYTE_E.MetaEvent
			}
			*/
			Invoke( PrintMidi, mData[0].ToString("X2") + " " + mData[1].ToString("X2") + " " + mData[2].ToString("X2") );
		}

		/// <summary>
		/// MIDI Inのロングメッセージ(System Exclusive)を受け取った時のイベントハンドラ
		/// まずはとりあえず表示だけさせてみる。
		/// 引数の中にF0,F7は含まれないので表示時に自分で足します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MidiInLongEvent(object sender, ReceivedExclusiveMessageEventArgs e)
		{
			int i=0;
			byte[] mData = new byte[e.Message.LongCount<byte>()]; //この中にF0、F7は含まれない。改善するTo Do
			string msg = "F0 ";

			foreach(byte m in e.Message)
			{
				mData[i++] = m;
				msg += m.ToString("X2") + " ";
			}

			Invoke(PrintMidi, msg + "F7");
		}

		//*****************************************************************
		//*****************************************************************
		//
		// 以下、フォームのイベント関連
		//
		//*****************************************************************
		//*****************************************************************

		/// <summary>
		/// MIDI Out選択が開始されたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_MidiOut_DropDown(object sender, EventArgs e)
		{
			int i;
			int outPortNum = MidiOut.GetPortCount();

			comboBox_MidiOut.Items.Clear();

			for (i = 0; i < outPortNum; i++)
			{
				comboBox_MidiOut.Items.Add(MidiOut.GetPortInformation(i).szPname);
			}
		}

		/// <summary>
		/// MIDI Outデバイスが選択されたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_MidiOut_SelectedIndexChanged(object sender, EventArgs e)
		{
			outPortName = comboBox_MidiOut.Text;
		}

		/// <summary>
		/// MIDI Out デバイスオープンボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_MidiOutOpen_Click(object sender, EventArgs e)
		{
			int i;
			int count = MidiOut.GetPortCount();

			for(i=0; i < count; i++)
			{
				if(outPortName == MidiOut.GetPortInformation(i).szPname)
				{
					midiOut = new MidiOut(i);
					button_MidiOutOpen.BackColor = SystemColors.ControlDarkDark;
					button_MidiOutClose.BackColor = SystemColors.Control;
					return;
				}
			}
		}

		/// <summary>
		/// MIDI Out デバイスクローズボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_MidiOutClose_Click(object sender, EventArgs e)
		{
			if(midiOut != null)
			{
				midiOut.Close();
				midiOut = null;
			}
			button_MidiOutOpen.BackColor = SystemColors.Control;
			button_MidiOutClose.BackColor = SystemColors.ControlDarkDark;
		}

		/// <summary>
		/// MIDI Out Sendボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Tx_Click(object sender, EventArgs e)
		{
			if (midiOut != null)
			{
				SendMidi();
			}
		}

		/// <summary>
		/// MIDI Outテキストボックスクリア
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_ClearTx_Click(object sender, EventArgs e)
		{
			textBox_MidiOut.ResetText();
		}

		/// <summary>
		/// MIDI In選択が開始されたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_MidiIn_DropDown(object sender, EventArgs e)
		{
			int i;
			int inPortNum = MidiIn.InputCount;

			comboBox_MidiIn.Items.Clear();

			for (i = 0; i < inPortNum; i++)
			{
				comboBox_MidiIn.Items.Add(MidiIn.InputDeviceNames[i]);
			}
		}

		/// <summary>
		/// MIDI Inデバイスが選択されたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_MidiIn_SelectedIndexChanged(object sender, EventArgs e)
		{
			inPortName = comboBox_MidiIn.Text;
		}

		/// <summary>
		/// MIDI In デバイスオープンボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_MidiInOpen_Click(object sender, EventArgs e)
		{
			int i;
			int count = MidiIn.InputCount;

			for (i = 0; i < count; i++)
			{
				if (inPortName == MidiIn.InputDeviceNames[i])
				{
					midiIn = new MidiIn(i);

					midiIn.ReceivedMidiEvent += MidiInShortEvent;
					midiIn.ReceivedExclusiveMessage += MidiInLongEvent;
					midiIn.Start();
					button_MidiInOpen.BackColor = SystemColors.ControlDarkDark;
					button_MidiInClose.BackColor = SystemColors.Control;
					return;
				}
			}
		}

		/// <summary>
		/// MIDI In デバイスクローズボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_MidiInClose_Click(object sender, EventArgs e)
		{
			if(midiIn != null)
			{
				midiIn.Dispose();
				midiIn = null;
			}
			button_MidiInOpen.BackColor = SystemColors.Control;
			button_MidiInClose.BackColor = SystemColors.ControlDarkDark;
		}

		/// <summary>
		/// MIDI Inテキストボックスクリア
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_ClearRx_Click(object sender, EventArgs e)
		{
			textBox_MidiIn.ResetText();
		}

		/// <summary>
		/// フォーム終了前処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (midiOut != null)
			{
				midiOut.Close();
				midiOut = null;
			}

			if (midiIn != null)
			{
				midiIn.Dispose();
				midiIn = null;
			}
		}
	}
}
