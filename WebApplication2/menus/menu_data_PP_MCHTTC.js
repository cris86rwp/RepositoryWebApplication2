Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mTC01= new Menu();var mTC05= new Menu();
var tmp;
mTC01.add(tmp = new MenuItem("Attendance Posting","/ppms/ttc/ttcAttendance.aspx"));tmp.mnemonic = '';mTC01.add(tmp = new MenuItem("TTC Query","/ppms/ttc/ttcquery.aspx"));tmp.mnemonic = '';mTC01.add(tmp = new MenuItem("Need Posting","/ppms/ttc/ttcTrainingNeedPosting.aspx"));tmp.mnemonic = '';mTC05.add(tmp = new MenuItem("Generate / Modify Attendance","/ppms/ttc/hr_ttc_AppAttendance_Details_Posting.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("T T C", mTC01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Apprentice Attendance", mTC05) );
tmp.mnemonic = '';

menuBar.write();
