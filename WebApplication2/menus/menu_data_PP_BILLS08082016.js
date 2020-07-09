Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mTC05= new Menu();var mB02= new Menu();var mY03= new Menu();var mB01= new Menu();
var tmp;
mB01.add(tmp = new MenuItem("Create Supp. Bill","/ppms/supplementary/supplimentaryBill.aspx?mode=add"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Add Employee EDs","/ppms/supplementary/supplimentaryBill.aspx?mode=add"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Modify Employee EDs","/ppms/supplementary/supplimentaryBill.aspx?mode=edit"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Delete Employee EDs","/ppms/supplementary/supplimentaryBill.aspx?mode=delete"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Query Supp. Bill","/ppms/supplementary/supplimentaryBill.aspx?mode=view"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print Supp. Bill","/ppms/supplementary/printSupplementarybill.aspx"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print Bill(Group unit )","/ppms/supplementary/rptSupplementaryBill_gu.rpt?user0=report&password0=report&user0@abc=report&password0@abc=report&user0@cde=report&password0@cde=report&user0@code_BU.rpt=report&password0@code_BU.rpt=report&user0@code_GU.rpt=report&password0@code_GU.rpt=report"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Generate CO7","/ppms/supplementary/co7Generation.aspx"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print CO7","/ppms/supplementary/printCO7.aspx"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print Supp. Bank Statement","/ppms/supplementary/printbankstatement.aspx"));tmp.mnemonic = '';mB02.add(tmp = new MenuItem("Create CO7","/ppms/auditBill/CO7Maintenance.aspx?mode=add"));tmp.mnemonic = '';mB02.add(tmp = new MenuItem("Correct CO7","/ppms/auditBill/CO7Maintenance.aspx?mode=edit"));tmp.mnemonic = '';mB02.add(tmp = new MenuItem("View CO7","/ppms/auditBill/CO7Maintenance.aspx?mode=view"));tmp.mnemonic = '';mTC05.add(tmp = new MenuItem("Generate / Modify Attendance","/ppms/ttc/hr_ttc_AppAttendance_Details_Posting.aspx"));tmp.mnemonic = '';mY03.add(tmp = new MenuItem("Withholding SettlementDues","/ppms/Settlement/whitholdingSettlementDues.aspx"));tmp.mnemonic = '';mY03.add(tmp = new MenuItem("Settlement Bill","/ppms/Settlement/hr_settlement_suppbill.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Apprentice Attendance", mTC05) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Audit Bill", mB02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Settlement", mY03) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Supplementary", mB01) );
tmp.mnemonic = '';

menuBar.write();
