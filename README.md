# MIDI通信テストプロジェクト

<h2> プロジェクト説明 </h2>
本プロジェクトは、C#でMIDI通信を行うテストプロジェクトです。
Windows Formから、Windowsで認識されているMIDIで認識されているMIDI Out、MIDI Inデバイスのオープン、クローズができます。<br>
MIDI Outテキストボックスに入力したMIDIメッセージ文字列はMIDI Outされます。<br>
MIDI Outテキストボックスには16進数で入力してください。'A'-'F'は大文字、小文字のどちらも受け付けます。<br>
区切り文字として使えるのは、半角スペース、カンマ、コロン、改行です。<br>
　(入力例)<br>
　　90407F<br>
　　90 40 7F<br>
　　90:40:7f<br>
　　90,40,7F<br>
　　0x90 0x40 0x7F<br>
また、MIDI Inデバイスから来たMIDIメッセージは、MIDI In テキストボックスに表示されます。<br>

本プロジェクトは、Visual Studio 2017での開発環境です。

<h2> ライセンス </h2>
本プロジェクトの一部のファイルの実装において、以下の著作者のライセンスが含まれます。

・MidiCommunicationTest/Event.cs, MidiCommunicationTest/MidiIn.cs: <b>MIT License</b>
	
	/* MidiUtils
	
	LICENSE - The MIT License (MIT)
	
	Copyright (c) 2013-2015 Tomona Nanase
	
	Permission is hereby granted, free of charge, to any person obtaining a copy of
	this software and associated documentation files (the "Software"), to deal in
	the Software without restriction, including without limitation the rights to
	use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
	the Software, and to permit persons to whom the Software is furnished to do so,
	subject to the following conditions:
	
	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.
	
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
	FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
	COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
	IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
	CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	*/
 
・MidiCommunicationTest/Midiout.cs: <b>New BSD Lisence</b>
	
	/*
	(C) 2009 Yokaze Rue. All rights reserved.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
	PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
	PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
	NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

    This section is quoted from:
    http://opensource.org/licenses/bsd-license.php
	*/
	
・その他のファイルはkeitwoのライセンスです。

	/*
	The MIT License
	
	Copyright (c) 2019 keitwo
	
	Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
	associated documentation files (the "Software"), to deal in the Software without restriction, including 
	without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
	copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to 
	the following conditions:
	
	The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
	
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
	LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
	IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
	WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
	SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	*/