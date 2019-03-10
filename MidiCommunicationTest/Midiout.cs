/*
(C) 2009 Yokaze Rue. All rights reserved.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

This section is quoted from:
http://opensource.org/licenses/bsd-license.php
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices; //for DLL import

namespace MidiCommunicationTest
{
	public static class MidiOutApi
	{
		/// <summary>  
		/// MIDI出力ポートの数を取得します。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutGetNumDevs")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern uint midiOutGetNumDevs();

		/// <summary>  
		/// MIDI出力ポートの情報を取得します。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutGetDevCapsA", CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutGetDevCapsA([MarshalAs(UnmanagedType.U4)] uint uDeviceID, ref MidiOutCapsA pMidiOutCaps, [MarshalAs(UnmanagedType.U4)] uint cbMidiOutCaps);

		/// <summary>  
		/// MIDI出力ポートを開きます。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutOpen")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutOpen([MarshalAs(UnmanagedType.SysUInt)] ref IntPtr lphMidiOut, [MarshalAs(UnmanagedType.U4)] uint uDeviceID, [MarshalAs(UnmanagedType.FunctionPtr)] Delegate dwCallback, [MarshalAs(UnmanagedType.U4)] uint dwInstance, [MarshalAs(UnmanagedType.U4)] MidiPortOpenFlag dwFlags);

		/// <summary>  
		/// MIDI出力ポートを閉じます。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutClose")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutClose([MarshalAs(UnmanagedType.SysUInt)] IntPtr hMidiOut);

		/// <summary>  
		/// MIDIショートメッセージを送信します。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutShortMsg")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutShortMsg([MarshalAs(UnmanagedType.SysUInt)] IntPtr hMidiOut, [MarshalAs(UnmanagedType.U4)] uint dwMsg);

		/// <summary>  
		/// MIDIロングメッセージを送信します。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutLongMsg")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutLongMsg([MarshalAs(UnmanagedType.SysUInt)] IntPtr hMidiOut, ref MidiHdr lpMidiOutHdr, [MarshalAs(UnmanagedType.U4)] uint uSize);

		/// <summary>  
		/// MIDI出力バッファを登録します。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutPrepareHeader")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutPrepareHeader([MarshalAs(UnmanagedType.SysUInt)] IntPtr hMidiOut, ref MidiHdr lpMidiOutHdr, [MarshalAs(UnmanagedType.U4)] uint uSize);

		/// <summary>  
		/// MIDI出力バッファの登録を解除します。  
		/// </summary>  
		[DllImport("winmm.dll", EntryPoint = "midiOutUnprepareHeader")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern MMResult midiOutUnprepareHeader([MarshalAs(UnmanagedType.SysUInt)] IntPtr hMidiOut, ref MidiHdr lpMidiOutHdr, [MarshalAs(UnmanagedType.U4)] uint uSize);
	}

	///f <summary>  
	/// MIDI APIで使用する定数です。  
	/// </summary>  
	public static class MidiPortConst
	{
		/// <summary>  
		/// TCHARで数えた時の文字数です。  
		/// </summary>  
		public const int MaxPNameLen = 32;
	}

	/// <summary>  
	/// MIDIポートの能力を示すフラグです。  
	/// </summary>  
	[Flags]
	public enum MidiPortCapability : uint
	{
		/// <summary>  
		/// ポートはボリュームコントロールをサポートします。  
		/// </summary>  
		Volume = 1,
		/// <summary>  
		/// ポートは左右独立のボリュームコントロールをサポートします。  
		/// </summary>  
		LRVolume = 2,
		/// <summary>  
		/// ポートはキャッシュをサポートします。  
		/// </summary>  
		Cache = 4,
		/// <summary>  
		/// ポートはMIDIストリームAPIをネイティブサポートします。  
		/// </summary>  
		Stream = 8
	}

	/// <summary>  
	/// MIDIポートの種類を表すフラグです。  
	/// </summary>  
	public enum MidiModuleType : ushort
	{
		/// <summary>  
		/// このポートはハードウェアポートです。  
		/// </summary>  
		Hardware = 1,
		/// <summary>  
		/// このポートはソフトウェアシンセサイザです。  
		/// </summary>  
		Synthesizer = 2,
		/// <summary>  
		/// このポートは矩形シンセサイザです。  
		/// </summary>  
		SquareSynth = 3,
		/// <summary>  
		/// このポートはFMシンセサイザです。  
		/// </summary>  
		FMSynth = 4,
		/// <summary>  
		/// このポートはMIDIマッパーです。  
		/// </summary>  
		MidiMapper = 5,
		/// <summary>  
		/// このポートはウェーブテーブルシンセサイザです。  
		/// </summary>  
		Wavetable = 6,
		/// <summary>  
		/// このポートはソフトウェアシンセサイザです。  
		/// </summary>  
		SoftwareSynth = 7
	}

	/// <summary>  
	/// MIDI出力ポートの情報を表します。  
	/// </summary>  
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct MidiOutCapsA
	{
		/// <summary>  
		/// MIDIハードウェアのメーカーIDです。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U2)]
		public ushort wMid;
		/// <summary>  
		/// Product IDです。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U2)]
		public ushort wPid;
		/// <summary>  
		/// ドライバーのバージョンです。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public uint vDriverVersion;
		/// <summary>  
		/// ポートの名前です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MidiPortConst.MaxPNameLen)]
		public string szPname;
		/// <summary>  
		/// wTechnology値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U2)]
		public MidiModuleType wTechnology;
		/// <summary>  
		/// 最大ボイス数を取得します。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U2)]
		public ushort wVoices;
		/// <summary>  
		/// 最大同時発音数を取得します。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U2)]
		public ushort wNotes;
		/// <summary>  
		/// チャンネルマスクを取得します。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U2)]
		public ushort wChannelMask;
		/// <summary>  
		/// dwSupport値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public MidiPortCapability dwSupport;

		/// <summary>  
		/// チャンネルマスクを取得します。  
		/// </summary>  
		public bool[] GetChannelMask()
		{
			bool[] mask = new bool[16];
			for (int i = 0; i < 16; i++)
			{
				mask[i] = (wChannelMask & (1 << i)) != 0;
			}
			return mask;
		}

		/// <summary>  
		/// チャンネルマスクを設定します。  
		/// </summary>  
		public void SetChannelMask(byte ch, bool value)
		{
			wChannelMask &= (ushort)(0xFFFF - 1 << ch);
			wChannelMask |= value ? (ushort)(1 << ch) : (ushort)0;
		}

		/// <summary>  
		/// デバイスドライバのメジャーバージョンを取得します。  
		/// </summary>  
		public byte MajorVersion
		{
			get { return (byte)(vDriverVersion >> 8); }
		}

		/// <summary>  
		/// デバイスドライバのマイナーバージョンを取得します。  
		/// </summary>  
		public byte MinorVersion
		{
			get { return (byte)(vDriverVersion & 0xFF); }
		}
	}

	/// <summary>  
	/// MMRESULTのマネージド実装です。  
	/// </summary>  
	public enum MMResult : uint
	{
		/// <summary>  
		/// 処理に成功しました。  
		/// </summary>  
		NoError = 0,
		/// <summary>  
		/// 指定されたIDは無効です。  
		/// </summary>  
		InvalidDeviceID = 2,
		/// <summary>  
		/// 指定されたリソースは既に割り当てられています。  
		/// </summary>  
		Allocated = 4
	}

	/// <summary>  
	/// MIDIポートを開く時のオプションです。  
	/// </summary>  
	public enum MidiPortOpenFlag : uint
	{
		/// <summary>  
		/// コールバック機構を使用しません。  
		/// </summary>  
		NoCallback = 0,
		/// <summary>  
		/// コールバックはウィンドウメッセージとして送信されます。  
		/// </summary>  
		CallbackWindow = 0x10000,
		/// <summary>  
		/// コールバックはスレッドに送信されます。  
		/// </summary>  
		CallbackThread = 0x20000,
		/// <summary>  
		/// コールバックは関数ポインタです。  
		/// </summary>  
		CallbackFunction = 0x30000
	}

	/// <summary>  
	/// マルチメディアリソースの割り当てに失敗したことを示すクラスです。  
	/// </summary>  
	public class MMAllocatedException : MMException
	{
		/// <summary>  
		/// MMAllocatedExceptionのインスタンスを作成します。  
		/// </summary>  
		public MMAllocatedException() : base("指定されたリソースは既に割り当てられています。") { }
	}

	/// <summary>  
	/// winmm.dllの呼び出し時に発生するエラーを表すクラスです。  
	/// </summary>  
	public class MMException : Exception
	{
		/// <summary>  
		/// MMExceptionのインスタンスを作成します。  
		/// </summary>  
		public MMException() : base("マルチメディアエラーが発生しました。") { }

		/// <summary>  
		/// MMExceptionのインスタンスを作成します。  
		/// </summary>  
		public MMException(string message) : base(message) { }
	}

	/// <summary>  
	/// MMResultの拡張クラスです。  
	/// </summary>  
	public static class MMResultExtensions
	{
		/// <summary>  
		/// MMResultがNoErrorでない場合にエラーを発生させます。  
		/// </summary>  
		public static void Throw(this MMResult result)
		{
			switch (result)
			{
				case MMResult.NoError:
					return;
				case MMResult.InvalidDeviceID:
					throw new ArgumentOutOfRangeException();
				case MMResult.Allocated:
					throw new MMAllocatedException();
				default:
					throw new MMException();
			}
		}
	}
	/// <summary>  
	/// 値の範囲をチェックする拡張クラスです。  
	/// </summary>  
	public static class Bounder
	{
		/// <summary>  
		/// オブジェクトがnull参照の時にエラーを発生させます。  
		/// </summary>  
		public static void CheckNotNull(this object target)
		{
			if (target == null)
			{
				throw new ArgumentNullException();
			}
		}
	}

	/// <summary>  
	/// MidiHdrのdwFlags値を表す列挙子です。  
	/// </summary>  
	[Flags]
	public enum MidiHdrFlag : uint
	{
		/// <summary>  
		/// フラグがセットされていません。  
		/// </summary>  
		None = 0,
		/// <summary>  
		/// バッファの使用が完了しました。  
		/// </summary>  
		Done = 1,
		/// <summary>  
		/// バッファの準備が完了しました。  
		/// </summary>  
		Prepared = 2,
		/// <summary>  
		/// バッファは再生待ちです。  
		/// </summary>  
		InQueue = 4
	}

	/// <summary>  
	/// MIDIHDR構造体のマネージド実装です。  
	/// </summary>  
	[StructLayout(LayoutKind.Sequential)]
	public struct MidiHdr
	{
		/// <summary>  
		/// MIDIデータのポインタです。  
		/// </summary>  
		[MarshalAs(UnmanagedType.SysUInt)]
		public IntPtr lpData;
		/// <summary>  
		/// バッファのサイズです。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public uint dwBufferLength;
		/// <summary>  
		/// 実際に入力されたデータのサイズです。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public uint dwBytesRecorded;
		/// <summary>  
		/// dwUser値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public uint dwUser;
		/// <summary>  
		/// MIDIヘッダーの状態を表します。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public MidiHdrFlag dwFlags;
		/// <summary>  
		/// lpNext値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.SysUInt)]
		public IntPtr lpNext;
		/// <summary>  
		/// reserved値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.SysUInt)]
		public IntPtr reserved;
		/// <summary>  
		/// dwOffset値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.U4)]
		public uint dwOffset;
		/// <summary>  
		/// dwReserved値です。  
		/// </summary>  
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public IntPtr[] dwReserved;
	}

	/// <summary>  
	/// MIDI出力ポートを抽象化するクラスです。  
	/// </summary>  
	public sealed class MidiOut : IDisposable
	{
		//----------// //----------// //----------// //----------//  
		//  
		//  Constructor  
		//  
		//----------// //----------// //----------// //----------//  

		/// <summary>  
		/// 指定した番号のポートを作成します。  
		/// </summary>  
		public MidiOut(int portNum)
		{
			name = GetPortInformation(portNum).szPname;
			MidiOutApi.midiOutOpen(ref hMidiOut, (uint)portNum, null, 0, MidiPortOpenFlag.NoCallback).Throw();
		}

		/// <summary>  
		/// MIDIポートハンドルを解放します。  
		/// </summary>  
		~MidiOut()
		{
			Release(true);
		}

		//----------// //----------// //----------// //----------//  
		//  
		//  Variables  
		//  
		//----------// //----------// //----------// //----------//  

		IntPtr hMidiOut = IntPtr.Zero;
		bool disposed = false;
		string name;

		//----------// //----------// //----------// //----------//  
		//  
		//  Methods (IDisposable)  
		//  
		//----------// //----------// //----------// //----------//  

		/// <summary>  
		/// MIDIポートハンドルを開放します。  
		/// </summary>  
		public void Close()
		{
			CheckDisposed();
			Dispose();
		}

		/// <summary>  
		/// MIDIポートハンドルを開放します。  
		/// </summary>  
		public void Dispose()
		{
			Release(false);
		}

		void CheckDisposed()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(name);
			}
		}

		void Release(bool finalizing)
		{
			if (disposed) return;

			if (!finalizing)
			{
				GC.SuppressFinalize(this);
			}
			disposed = true;
			MidiOutApi.midiOutClose(hMidiOut).Throw();
		}

		//----------// //----------// //----------// //----------//  
		//  
		//  Methods  
		//  
		//----------// //----------// //----------// //----------//  

		/// <summary>  
		/// MIDI出力ポートの数を取得します。  
		/// </summary>  
		public static int GetPortCount()
		{
			return (int)MidiOutApi.midiOutGetNumDevs();
		}

		/// <summary>  
		/// MIDI出力ポートの情報を取得します。  
		/// </summary>  
		public static MidiOutCapsA GetPortInformation(int portNum)
		{
			var caps = new MidiOutCapsA();
			MidiOutApi.midiOutGetDevCapsA((uint)portNum, ref caps, (uint)Marshal.SizeOf(typeof(MidiOutCapsA))).Throw();

			return caps;
		}

		//----------// //----------// //----------// //----------//  
		//  
		//  Properties  
		//  
		//----------// //----------// //----------// //----------//  

		/// <summary>  
		/// ポートの名前です。  
		/// </summary>  
		public string Name
		{
			get
			{
				CheckDisposed();
				return name;
			}
		}

		/// <summary>  
		/// MIDIデータを送信します。  
		/// </summary>  
		public void Send(byte[] data)
		{
			CheckDisposed();
			data.CheckNotNull();
			if (data.Length == 0)
			{
				return;
			}
			if (data.Length <= 4)
			{
				SendShortMessage(data);
			}
			else
			{
				SendLongMessage(data);
			}
		}

		/// <summary>  
		/// 4バイト以内のMIDIメッセージ(Short Message)を送信します。  
		/// </summary>  
		void SendShortMessage(byte[] data)
		{
			uint message = 0;

			for (int i = 0; i < data.Length; i++)
			{
				message |= ((uint)data[i]) << (i * 8);
			}

			MidiOutApi.midiOutShortMsg(hMidiOut, message);
		}

		static int maxBufferSize = 64 * 1024;
		static uint hdrSize = (uint)Marshal.SizeOf(typeof(MidiHdr));

		/// <summary>  
		/// 5バイト以上のMIDIメッセージ(Long Message)を送信します。  
		/// </summary>  
		void SendLongMessage(byte[] data)
		{
			if (data.Length > maxBufferSize)
			{
				throw new InvalidOperationException();
			}

			MidiHdr hdr = new MidiHdr();
			hdr.dwReserved = new IntPtr[8];

			GCHandle dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);

			try
			{
				hdr.lpData = dataHandle.AddrOfPinnedObject();
				hdr.dwBufferLength = (uint)data.Length;
				hdr.dwFlags = 0;

				SendBuffer(hdr);
			}
			finally
			{
				dataHandle.Free();
			}
		}

		void SendBuffer(MidiHdr hdr)
		{
			MidiOutApi.midiOutPrepareHeader(hMidiOut, ref hdr, hdrSize).Throw();
			while ((hdr.dwFlags & MidiHdrFlag.Prepared) != MidiHdrFlag.Prepared)
			{
				Thread.Sleep(1);
			}

			MidiOutApi.midiOutLongMsg(hMidiOut, ref hdr, hdrSize).Throw();

			while ((hdr.dwFlags & MidiHdrFlag.Done) != MidiHdrFlag.Done)
			{
				Thread.Sleep(1);
			}
			MidiOutApi.midiOutUnprepareHeader(hMidiOut, ref hdr, hdrSize).Throw();
		}
	}
}
