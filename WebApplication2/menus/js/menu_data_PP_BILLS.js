Menu.prototype.cssFile = '/wap/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/wap/menus/skins/officexp/officexp.css';
var mB02= new Menu();var mB01= new Menu();
var tmp;
mB01.add(tmp = new MenuItem("Create Supp. Bill","/wap/ppms/supplementary/supplimentaryBill.aspx?mode=add"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Add Employee EDs","/wap/ppms/supplementary/supplimentaryBill.aspx?mode=add"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Modify Employee EDs","/wap/ppms/supplementary/supplimentaryBill.aspx?mode=edit"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Delete Employee EDs","/wap/ppms/supplementary/supplimentaryBill.aspx?mode=delete"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Query Supp. Bill","/wap/ppms/supplementary/supplimentaryBill.aspx?mode=view"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print Supp. Bill","/wap/ppms/supplementary/printSupplementarybill.aspx"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print Bill(Group unit )","/wap/ppms/supplementary/rptSupplementaryBill_gu.rpt?user0=report&password0=report&user0@abc=report&password0@abc=report&user0@cde=report&password0@cde=report&user0@code_BU.rpt=report&password0@code_BU.rpt=report&user0@code_GU.rpt=report&password0@code_GU.rpt=report"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Generate CO7","/wap/ppms/supplementary/co7Generation.aspx"));tmp.mnemonic = '';mB01.add(tmp = new MenuItem("Print CO7","/wap/ppms/supplementary/printCO7.aspx"));tmp.mnemonic = '';mB02.add(tmp = new MenuItem("Create CO7","/wap/ppms/auditBill/CO7Maintenance.aspx?mode=add"));tmp.mnemonic = '';mB02.add(tmp = new MenuItem("Correct CO7","/wap/ppms/auditBill/CO7Maintenance.aspx?mode=edit"));tmp.mnemonic = '';mB02.add(tmp = new MenuItem("View CO7","/wap/ppms/auditBill/CO7Maintenance.aspx?mode=view"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Audit Bill", mB02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Supplementary", mB01) );
tmp.mnemonic = '';

menuBar.write();
