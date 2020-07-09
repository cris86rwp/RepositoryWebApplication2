Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mT80= new Menu();var mT81= new Menu();var mT86= new Menu();
var tmp;
mT80.add(tmp = new MenuItem("TA Journal entry",null,null, mT81) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("Contingency/conveyance",null,null, mT86) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("TA Journal/Contingency printing","/ppms/ta/RptTravellingAllowance.aspx"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Add","/ppms/ta/ta1.aspx?mode=add"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Delete","/ppms/ta/editTA.aspx?mode=delete"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Add","/ppms/ta/ta2.aspx?mode=add"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Delete","/ppms/ta/deleteTA2.aspx?mode=delete"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("POST T.A./CONVAYANCE", mT80) );
tmp.mnemonic = '';

menuBar.write();
