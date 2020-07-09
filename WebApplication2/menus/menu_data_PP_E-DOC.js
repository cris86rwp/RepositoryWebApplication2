Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var m001= new Menu();
var tmp;
m001.add(tmp = new MenuItem("E-Doc Management","/ppms/EDocuments/hr_EDocument_AddEdit.aspx"));tmp.mnemonic = '';m001.add(tmp = new MenuItem("Upload Hyperlink File to E-Doc","/ppms/EDocuments/hr_EDocument_UpLoadFile.aspx"));tmp.mnemonic = '';m001.add(tmp = new MenuItem("View E-Documents","/ppms/EDocuments/hr_EDocument_View.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("E-Document", m001) );
tmp.mnemonic = '';

menuBar.write();
