Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mP01= new Menu();var mTM00= new Menu();var mP10= new Menu();var mP11= new Menu();var mP13= new Menu();var mP14= new Menu();var mP15= new Menu();var mP16= new Menu();var mP17= new Menu();var mP18= new Menu();var mP21= new Menu();var mP22= new Menu();var mP101= new Menu();
var tmp;
mP01.add(tmp = new MenuItem("New Employees",null,null, mP10) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Transfered Employees",null,null, mP11) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Modify Employee Details","/ppms/PPEM01"));tmp.mnemonic = '';mP01.add(tmp = new MenuItem("Employee List for CR","/ppms/SECLIST2"));tmp.mnemonic = '';mP01.add(tmp = new MenuItem("Employee Service Review","/ppms/SERVREV"));tmp.mnemonic = '';mP01.add(tmp = new MenuItem("Bio-Data",null,null, mP13) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Family Particulars",null,null, mP14) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Permanent Address",null,null, mP15) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Local Address",null,null, mP16) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Qualification",null,null, mP17) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Medical Test",null,null, mP18) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("DAR/CAT Cases",null,null, mP21) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Remb.Tution Fee",null,null, mP22) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("View Brief Details",null,null, mP101) );
tmp.mnemonic = ' ';
mTM00.add(tmp = new MenuItem("LPC","/ppms/lpc/rptLastPayCertificate_backup.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mP10.add(tmp = new MenuItem("Create","/ppms/employee/employeeDetailsMaintenance.aspx?mode=add"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("View","/ppms/employee/editEmployeeMaster.aspx?mode=view"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("Delete","/ppms/employee/editEmployeeMaster.aspx?mode=delete"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("Check List","/ppms/PPCHK16"));tmp.mnemonic = '';mP10.add(tmp = new MenuItem("Post To Payroll","/ppms/PPEM01"));tmp.mnemonic = '';mP101.add(tmp = new MenuItem("On Code","/ppms/employee/EmployeeDetailsOnCode.aspx"));tmp.mnemonic = ' ';mP101.add(tmp = new MenuItem("On Name","/ppms/employee/EmployeeDetailsOnName.aspx"));tmp.mnemonic = ' ';mP11.add(tmp = new MenuItem("Create","/ppms/employee/employeeDetailsMaintenance.aspx?mode=add"));tmp.mnemonic = '';mP11.add(tmp = new MenuItem("Edit","/ppms/employee/employeeDetailsMaintenance.aspx?mode=edit"));tmp.mnemonic = '';mP11.add(tmp = new MenuItem("View","/ppms/employee/employeeDetailsMaintenance.aspx?mode=view"));tmp.mnemonic = '';mP11.add(tmp = new MenuItem("Delete","/ppms/employee/employeeDetailsMaintenance.aspx?mode=delete"));tmp.mnemonic = '';mP11.add(tmp = new MenuItem("Check List","/ppms/PPCHK16"));tmp.mnemonic = '';mP11.add(tmp = new MenuItem("Post To Payroll","/ppms/PPEM02"));tmp.mnemonic = '';mP13.add(tmp = new MenuItem("Add","/ppms/employee/bioDataDetails.aspx?mode=add"));tmp.mnemonic = '';mP13.add(tmp = new MenuItem("Modify","/ppms//employee/biodataDetails.aspx?mode=edit"));tmp.mnemonic = '';mP13.add(tmp = new MenuItem("Check List","/ppms/Reports/formats/Checklist/EmployeepersonnelDetails.aspx?mode=ChecklistEmployeePerDetails.rpt"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Add","/ppms/employee/employeeFamily.aspx?mode=add"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Modify","/ppms/employee/employeeFamily.aspx?mode=edit"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Delete","/ppms/employee/employeeFamily.aspx?mode=delete"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Query","/ppms/employee/employeeFamily.aspx?mode=view"));tmp.mnemonic = '';mP14.add(tmp = new MenuItem("Check List","/ppms/Reports/formats/checklist/Checklist.aspx?mode=ChecklistFamilyDetails"));tmp.mnemonic = '';mP15.add(tmp = new MenuItem("Create","/ppms/employee/employeePermanentAddress.aspx?mode=add"));tmp.mnemonic = '';mP15.add(tmp = new MenuItem("Modify","/ppms/employee/employeePermanentAddress.aspx?mode=edit"));tmp.mnemonic = '';mP15.add(tmp = new MenuItem("Query","/ppms/employee/employeePermanentAddress.aspx?mode=view"));tmp.mnemonic = '';mP15.add(tmp = new MenuItem("Check List","/ppms/PPCHK52"));tmp.mnemonic = '';mP16.add(tmp = new MenuItem("Add","/ppms/employee/employeeLocalAddress.aspx?mode=add"));tmp.mnemonic = '';mP16.add(tmp = new MenuItem("Modify","/ppms/employee/employeeLocalAddress.aspx?mode=edit"));tmp.mnemonic = '';mP16.add(tmp = new MenuItem("Delete","/ppms/employee/employeeLocalAddress.aspx?mode=delete"));tmp.mnemonic = '';mP16.add(tmp = new MenuItem("Query","/ppms/employee/employeeLocalAddress.aspx?mode=view"));tmp.mnemonic = '';mP16.add(tmp = new MenuItem("Check List","/ppms/Reports/formats/checklist/Checklist.aspx?mode=CheckListLocalAddress"));tmp.mnemonic = '';mP17.add(tmp = new MenuItem("Add","/ppms/employee/employeeQualification.aspx?mode=add"));tmp.mnemonic = '';mP17.add(tmp = new MenuItem("Modify","/ppms/employee/employeeQualification.aspx?mode=edit"));tmp.mnemonic = '';mP17.add(tmp = new MenuItem("Delete","/ppms/employee/employeeQualification.aspx?mode=delete"));tmp.mnemonic = '';mP17.add(tmp = new MenuItem("Query","/ppms/employee/employeeQualification.aspx?mode=view"));tmp.mnemonic = '';mP17.add(tmp = new MenuItem("Check List","/ppms/Reports/formats/checklist/Checklist.aspx?mode=ChecklistQualificationDetails"));tmp.mnemonic = '';mP18.add(tmp = new MenuItem("Add","/ppms/employee/employeeMedicalTestDetails.aspx?mode=add"));tmp.mnemonic = '';mP18.add(tmp = new MenuItem("Modify","/ppms/employee/employeeMedicalTestDetails.aspx?mode=edit"));tmp.mnemonic = '';mP18.add(tmp = new MenuItem("Delete","/ppms/employee/employeeMedicalTestDetails.aspx?mode=delete"));tmp.mnemonic = '';mP18.add(tmp = new MenuItem("Query","/ppms/employee/employeeMedicalTestDetails.aspx?mode=view"));tmp.mnemonic = '';mP18.add(tmp = new MenuItem("Check List","/ppms/PPMR01"));tmp.mnemonic = '';mP21.add(tmp = new MenuItem("Add","/ppms/PPDAR"));tmp.mnemonic = '';mP21.add(tmp = new MenuItem("Modify","/ppms/PPDAR"));tmp.mnemonic = '';mP21.add(tmp = new MenuItem("Delete","/ppms/PPDAR"));tmp.mnemonic = '';mP21.add(tmp = new MenuItem("Query","/ppms/PPDAR"));tmp.mnemonic = '';mP21.add(tmp = new MenuItem("Reports","/ppms/DARRPT"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Add","/ppms/employee/reimbursementOfTutionFee.aspx?mode=add"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Modify","/ppms/employee/TutionFeeDetailsEdit.aspx?mode=edit"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Delete","/ppms/employee/TutionFeeDetailsEdit.aspx?mode=delete"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Query","/ppms/employee/EmpReimbursement.aspx?mode=view"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Print Check List","/ppms/employee/reimbTutionFeeCheckList.aspx?mode=rptReimbCheckList"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Post To Supp.Pay","/ppms/employee/ReimbursmentOfTutionFees.aspx"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Sanction","/ppms/employee/reimbursementOfTutionFeeSanctioned.aspx"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Generate Memorandum","/ppms/employee/SanctionReimbursement.aspx"));tmp.mnemonic = ' ';mP22.add(tmp = new MenuItem("Print Office Order","/ppms/employee/reimbTutionFeeOffOrder.aspx?mode=rptReimbOffOrder"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Employee", mP01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Temp", mTM00) );
tmp.mnemonic = ' ';

menuBar.write();