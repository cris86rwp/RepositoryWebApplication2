Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mVBEX= new Menu();
var tmp;
mVBEX.add(tmp = new MenuItem("Pass","/ppms/vbExe/Train Pass Executable/setup.exe"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("VB Exe Files", mVBEX) );
tmp.mnemonic = ' ';

menuBar.write();
