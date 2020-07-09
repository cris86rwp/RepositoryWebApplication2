Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mMGM= new Menu();var mMNT= new Menu();
var tmp;
mMGM.add(tmp = new MenuItem("Post Messages","/ppms/frmNoticeBoard.aspx"));tmp.mnemonic = '';mMNT.add(tmp = new MenuItem("News Management","/ppms/RWF_News_AddEdit.aspx"));tmp.mnemonic = '';mMNT.add(tmp = new MenuItem("Upload Hyperlink File to RWF News","http://server/rwfhome/UpLoadFile.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Messages", mMGM) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("RWF NEWS", mMNT) );
tmp.mnemonic = '';

menuBar.write();
