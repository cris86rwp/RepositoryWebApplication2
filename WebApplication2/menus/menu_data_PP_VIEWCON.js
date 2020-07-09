Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mP01= new Menu();var mQYM= new Menu();
var tmp;
mP01.add(tmp = new MenuItem("View Service Record(Confidential)","/ppms/Employee/hr_employee_SRGlobalView.aspx"));tmp.mnemonic = '';mP01.add(tmp = new MenuItem("View APAR(Confidential)","/ppms/Employee/hr_employee_APARGlobalView.aspx"));tmp.mnemonic = '';mP01.add(tmp = new MenuItem("Employee CRs","/ppms/Reports/Formats/CRFormats/CRFORMATS.ASPX"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("HR-General Queries","/ppms/hrquery.aspx"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("H.R - QUERIES - Add","/ppms/AddPPMSquery.aspx?mode=add"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("H.R - QUERIES - Edit","/ppms/AddPPMSquery.aspx?mode=edit"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Employee", mP01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("HR-QUERIES", mQYM) );
tmp.mnemonic = '';

menuBar.write();
