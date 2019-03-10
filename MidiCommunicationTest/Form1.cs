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

		void PrintMidiExe(string msg)
		{
			textBox_MidiIn.AppendText(msg + "\r\n");
		}

		/// <summary>
		/// MIDI Outテキストボックス内に記載されたメッセージをバイナリに変換して送信します。
		/// </summary>
		void SendMidi()
		{

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
					midiOut.Send(new byte[] { 0xF0, 0x40, 0x7F, 0x00, 0xF7 });
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

		/// <summary>
		/// Sendボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Tx_Click(object sender, EventArgs e)
		{
			SendMidi();
		}
	}
}
