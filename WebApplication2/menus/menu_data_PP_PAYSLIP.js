Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mZ02= new Menu();var mPPR0= new Menu();var mZ12= new Menu();var mZ66= new Menu();
var tmp;
mPPR0.add(tmp = new MenuItem("View","/ppms/payslip/frmPayslip.aspx"));tmp.mnemonic = ' ';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Payroll Reports",null,null, mZ66) );
tmp.mnemonic = '';
mZ66.add(tmp = new MenuItem("A4 PaySlip Printing","/ppms/Reports/Formats/rptPayroll/hr_rpt_Payslips_report.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Pay Slip View", mPPR0) );
tmp.mnemonic = ' ';

menuBar.write();
