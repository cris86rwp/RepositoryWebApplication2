Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var m006= new Menu();var mT80= new Menu();var mF00= new Menu();var mZ02= new Menu();var mQYM= new Menu();var mF03= new Menu();var mT81= new Menu();var mT86= new Menu();var mZ12= new Menu();var mZ66= new Menu();
var tmp;
m006.add(tmp = new MenuItem("Payroll Process","/ppms/payroll/payroll.aspx?mode=P"));tmp.mnemonic = '';mF00.add(tmp = new MenuItem("Accounts Transaction",null,null, mF03) );
tmp.mnemonic = '';
mQYM.add(tmp = new MenuItem("HR-General Queries","/ppms/hrquery.aspx"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("H.R - QUERIES - Add","/ppms/AddPPMSquery.aspx?mode=add"));tmp.mnemonic = '';mQYM.add(tmp = new MenuItem("H.R - QUERIES - Edit","/ppms/AddPPMSquery.aspx?mode=edit"));tmp.mnemonic = '';mT80.add(tmp = new MenuItem("TA Journal entry",null,null, mT81) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("Contingency/conveyance",null,null, mT86) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("TA Journal/Contingency printing","/ppms/ta/RptTravellingAllowance.aspx"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Add","/ppms/ta/ta1.aspx?mode=add"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Delete","/ppms/ta/editTA.aspx?mode=delete"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("TA / Contingency - Bulk Copy","/ppms/ta/hr_ta_CopytoEmployee.aspx"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Add","/ppms/ta/ta2.aspx?mode=add"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Delete","/ppms/ta/deleteTA2.aspx?mode=delete"));tmp.mnemonic = '';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Payroll Reports",null,null, mZ66) );
tmp.mnemonic = '';
mF03.add(tmp = new MenuItem("Create","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=add"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("Modify","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=edit"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("Delete","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=delete"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("View","/ppms/pf/pfAccountsTransactionMaintenance.aspx?mode=view"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("Check List","/ppms/Reports/formats/rptpf/pfTransactionCheckList.aspx?mode=PFCheckList.rpt"));tmp.mnemonic = '';mF03.add(tmp = new MenuItem("Error List","/ppms/reports/formats/rptpf/pfTransactionErrorList.aspx?mode=PFErrorList.rpt"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("A4 PaySlip Printing","/ppms/Reports/Formats/rptPayroll/hr_rpt_Payslips_report.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Payroll", m006) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("POST T.A./CONVAYANCE", mT80) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Provident Fund", mF00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("HR-QUERIES", mQYM) );
tmp.mnemonic = '';

menuBar.write();
