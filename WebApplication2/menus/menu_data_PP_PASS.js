Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mP01= new Menu();var mS02= new Menu();var mP10= new Menu();var mP14= new Menu();var mP19= new Menu();var mP101= new Menu();
var tmp;
mP01.add(tmp = new MenuItem("New Employees",null,null, mP10) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Family Particulars",null,null, mP14) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Study Certificate",null,null, mP19) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("View Brief Details",null,null, mP101) );
tmp.mnemonic = ' ';
mS02.add(tmp = new MenuItem("Application","/ppms/passes/applicationForPassPTO.aspx?mode=add"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("Issue","/ppms/passes/IssuePassPTO.aspx"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("Cancel","/ppms/passes/pass_application_delete.aspx?mode=cancel"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("Accountal Pass","/ppms/passes/applicationForPassPTO.aspx?mode=accountal"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("PRINT","/ppms/passes/rptPassPrint.aspx"));tmp.mnemonic = ' ';mS02.add(tmp = new MenuItem("Pass Details","/ppms/passes/pass_details.aspx"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("Pass Balance","/ppms//passes/pass_balance.aspx"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("PTO Print","/ppms/passes/passPTOPrint.aspx"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("Edit","/ppms/employee/editEmployeeMaster.aspx?mode=edit"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("View","/ppms/employee/editEmployeeMaster.aspx?mode=view"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("Check List","/ppms/PPCHK16"));tmp.mnemonic = '';mP101.add(tmp = new MenuItem("On Code","/ppms/employee/EmployeeDetailsOnCode.aspx"));tmp.mnemonic = ' ';mP101.add(tmp = new MenuItem("On Name","/ppms/employee/EmployeeDetailsOnName.aspx"));tmp.mnemonic = ' ';mP14.add(tmp = new MenuItem("Add","/ppms/employee/employeeFamily.aspx?mode=add"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Modify","/ppms/employee/employeeFamily.aspx?mode=edit"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Delete","/ppms/employee/employeeFamily.aspx?mode=delete"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Query","/ppms/employee/employeeFamily.aspx?mode=view"));tmp.mnemonic = '';mP19.add(tmp = new MenuItem("Add","/ppms/employee/EmployeeFamilyssn.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Employee", mP01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Pass Issues", mS02) );
tmp.mnemonic = '';

menuBar.write();
