Gamodo.Studio
=============

From 2008 to 2009 I've wrote a little "web ide" with c# in my spare time. It was developed mainly for educational purpose. I've found this old project lying around on my hard drive and thought I could help some young programmers to write their own ide :). It is now released under MIT license. I have to apologize if the code is a little bit messy and I didn't had time to rewrite all comments in English so you maybe find German comments. Though it runs on new systems like windows 7, windows 8 it was developed on windows xp. So some things might be broken.

To be absolutely clear, this project was developed in 2009 and is not going to be continued. It is only released for educational purpose.

You need Visual Studio 2008.

## Gamodo Studio

![Mainscreen](/screens/mainscreen.jpg)

Here are some features that are stable at the moment. There are lots of features I've started to implement but couldn't finish it, there are not listed here.

## Code Parser

My code parser works for html, css, js and php though in this release only html and css works fine.
![Code Browser](/screens/parser.jpg)

## Quicklet™ Engine (Snippets)

I've developed a high customizable snippet engine I call Quicklets. Nowadays every good IDE has this feature. But back in 2008 only visual studio and gamodo studio had this powerful snippet engine. Even some popular Editors today don't have a good snippet engine like this. Just look at Sublime's implementation, no offense.  Quicklets are defined in a xml file. To trigger a Quicklet you have to type the keyword and hit Tab. You can Tab between defined variables or code segments.
![Quicklet](/screens/code_browser.jpg)

Sample Quicklet xml

	<Template shortcut="class" text="class $classname$ extends $anotherclass$ {\n\n\tfunction $funcname$($argument$) {\n\t\t$end$\n\t}\n}" variables="4" docLang="0">
	    <Variable name="$classname$" value="ClassName" />
	    <Variable name="$anotherclass$" value="AnotherClass" />
	    <Variable name="$funcname$" value="__construct" />
	    <Variable name="$argument$" value="$argument" />
	</Template>

## Editor Control

I used the SharpDevelop Control as basis, at the time of writing it wasn't maintained by the SharpDevelop Team so I continued development and basically implemented all features Visual Studio 2008 had at this point. So if you are searching for a great Editor Control for WinForms, I recommand using mine. As far as I know, it is the most stable and feature richest Editor Control for WinForms out there.

![Editor Control](/screens/editor_control.jpg)

## Code completion

HTML is fully supported (other languages can be added easily) even with events, attributes and help text in german and english.

![code completion](/screens/code_completion.jpg)

## Help Browser

I've wrote a little Help Browser. It can load from different sources. 

![Help Browser](/screens/help_browser.jpg)

## License

    The MIT License (MIT)

    Copyright (c) 2015 Henry Keller <henry@creativemind.info>

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

