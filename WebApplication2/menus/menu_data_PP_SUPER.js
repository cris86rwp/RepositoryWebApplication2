Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mQYM= new Menu();
var tmp;
mQYM.add(tmp = new MenuItem("HR-General Queries","/ppms/hrquery.aspx"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("H.R - QUERIES - Add","/ppms/AddPPMSquery.aspx?mode=add"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("H.R - QUERIES - Edit","/ppms/AddPPMSquery.aspx?mode=edit"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("HR-QUERIES", mQYM) );
tmp.mnemonic = '';

menuBar.write();
