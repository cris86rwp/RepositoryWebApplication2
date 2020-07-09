Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mA01= new Menu();
var tmp;
mA01.add(tmp = new MenuItem("Add Employee","/ppms/CareerEvents/careerEventsNoting.aspx?mode=add"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Modify Employee","/ppms/CareerEvents/careerEventsNoting.aspx?mode=edit"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Delete Employee","/ppms/CareerEvents/careerEventsNoting.aspx?mode=delete"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Query Noting","/ppms/CareerEvents/careerEventsQuery.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("EditNotingText","/ppms/CareerEvents/careerEventsEditNotingText.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Noting","/ppms/CareerEvents/printNotingCE.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("EditOfficeOrderText","/ppms/CareerEvents/careerEventsOfficeOrderText.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Generate Office Order","/ppms/CareerEvents/careerEventsOfficeOrdNumber.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Office Order","/ppms/CareerEvents/printOfficeorderCE.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Update Taken Charge Date","/ppms/CareerEvents/careerEventsChargeUpdate.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Taken Charge Order","/ppms/CareerEvents/printTakenchargeorder.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Unposted Entries","/ppms/CareerEvents/printUnpostedentries.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Post Entries To Payroll","/ppms/CareerEvents/careerEventsPayrollPosting.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Office Order Detail","/ppms/CareerEvents/printOfficeorderCE.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("List Employee Dept. Wise","/ppms/CareerEvents/printListemployeecodewise.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Career Events", mA01) );
tmp.mnemonic = '';

menuBar.write();
