Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mD50= new Menu();var mD61= new Menu();
var tmp;
mD50.add(tmp = new MenuItem("Training Details","/ppms/sr/hr_sr_trainingdetails.aspx"));tmp.mnemonic = '';mD61.add(tmp = new MenuItem("SAKSHAM","/ppms/sr/rptsSaksham.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Service Register - Entry", mD50) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Report", mD61) );
tmp.mnemonic = '';

menuBar.write();
