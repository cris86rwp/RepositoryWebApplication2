Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mZ02= new Menu();var mPPR0= new Menu();var mZ12= new Menu();var mZ61= new Menu();var mZ63= new Menu();var mZ49= new Menu();var mZ20= new Menu();
var tmp;
mPPR0.add(tmp = new MenuItem("View","/ppms/payslip/frmPayslip.aspx"));tmp.mnemonic = ' ';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Increment Reports",null,null, mZ61) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Employee Lists",null,null, mZ63) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Exception Reports",null,null, mZ49) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("ChequeStatement",null,null, mZ20) );
tmp.mnemonic = '';
mZ20.add(tmp = new MenuItem("Employeewise","/ppms/Reports/formats/chequestatement/employee.aspx?mode=EmployeeWise"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("AccountNowise","/ppms/Reports/formats/chequestatement/employee.aspx?mode=AccountNowise"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Societies","/ppms/Reports/formats/chequestatement/societies.aspx?mode=Societies"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Bankstatement","/ppms/Reports/formats/chequestatement/BankwiseStatement.aspx?mode=Bankstatement"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("PLI","/ppms/Reports/formats/chequestatement/societies.aspx?mode=PLI"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Bankwisestatement","/ppms/Reports/formats/chequestatement/BankwiseStatement.aspx?mode=Bankwisestatement"));tmp.mnemonic = '';mZ49.add(tmp = new MenuItem("No Insurance","/ppms/Reports/formats/ExceptionReports/rptExceptions.aspx?mode=rptNoInsurance"));tmp.mnemonic = '';mZ49.add(tmp = new MenuItem("House Rent - No E/D","/ppms/Reports/formats/ExceptionReports/rptExceptions.aspx?mode=rptHouseRentNoED"));tmp.mnemonic = '';mZ49.add(tmp = new MenuItem("House Rent - Both E/D","/ppms/Reports/formats/ExceptionReports/rptExceptions.aspx?mode=rptHouseRentBothED"));tmp.mnemonic = '';mZ61.add(tmp = new MenuItem("Due List","/ppms/Reports/formats/rptIncrements/rptIncrement.aspx?mode=rptIncrementDueList"));tmp.mnemonic = '';mZ63.add(tmp = new MenuItem("Without PF Nomination","/ppms/Reports/formats/rptEmployeeList/rptEmployeeWithoutPF.aspx?mode=rptEmployeeListWithoutPF"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Pay Slip View", mPPR0) );
tmp.mnemonic = ' ';

menuBar.write();
