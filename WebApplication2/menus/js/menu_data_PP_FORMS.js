Menu.prototype.cssFile = '/wap/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/wap/menus/skins/officexp/officexp.css';
var mP01= new Menu();var mG00= new Menu();var mL02= new Menu();var mT80= new Menu();var mF00= new Menu();var mQ00= new Menu();var mY03= new Menu();var mF06= new Menu();var mF11= new Menu();var mG01= new Menu();var mG25= new Menu();var mL03= new Menu();var mP22= new Menu();var mQ001= new Menu();var mT81= new Menu();var mT86= new Menu();var mL04= new Menu();var mQ002= new Menu();
var tmp;
mF00.add(tmp = new MenuItem("PF Final Withdrawals",null,null, mF06) );
tmp.mnemonic = '';
mF00.add(tmp = new MenuItem("PF Temporary Withdrawal",null,null, mF11) );
tmp.mnemonic = '';
mF00.add(tmp = new MenuItem("Application Prints","/wap/ppms/Reports/Formats/rptPF/pfPrintApplications.aspx"));tmp.mnemonic = '';mG00.add(tmp = new MenuItem("Loan Applications",null,null, mG01) );
tmp.mnemonic = '';
mG00.add(tmp = new MenuItem("Application Prints",null,null, mG25) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Remb.Tution Fee",null,null, mP22) );
tmp.mnemonic = '';
mP01.add(tmp = new MenuItem("Blood Group Updation","/wap/ppms/employee/HrBloodGroup.aspx"));tmp.mnemonic = '';mQ00.add(tmp = new MenuItem("Application",null,null, mQ001) );
tmp.mnemonic = ' ';
mT80.add(tmp = new MenuItem("TA Journal entry",null,null, mT81) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("Contingency/conveyance",null,null, mT86) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("TA Journal/Contingency printing","/wap/ppms/ta/RptTravellingAllowance.aspx"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Add","/wap/ppms/ta/ta1.aspx?mode=add"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Delete","/wap/ppms/ta/editTA.aspx?mode=delete"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Add","/wap/ppms/ta/ta2.aspx?mode=add"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Delete","/wap/ppms/ta/deleteTA2.aspx?mode=delete"));tmp.mnemonic = '';mY03.add(tmp = new MenuItem("Employee Pension Application","/wap/ppms/Settlement/employeePension.aspx"));tmp.mnemonic = '';mY03.add(tmp = new MenuItem("Application Forms","/wap/ppms/Settlement/pensionReports.aspx"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("PF Withdrawal - Marriage","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F38"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("PF Withdrawal - Medical","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F39"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("PF Withdrawal - HBA","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F40"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("Pf Withdrawal - Others","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F41"));tmp.mnemonic = '';mF11.add(tmp = new MenuItem("PF Withdrawal - Temporary","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F42"));tmp.mnemonic = '';mG01.add(tmp = new MenuItem("Car/Motor Cycle/Scooter/Computer","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=G031"));tmp.mnemonic = '';mG01.add(tmp = new MenuItem("Bicycle Loan","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=G032"));tmp.mnemonic = '';mG01.add(tmp = new MenuItem("Festival Loan","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=G033"));tmp.mnemonic = '';mG01.add(tmp = new MenuItem("HBA","/wap/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=G034"));tmp.mnemonic = '';mG25.add(tmp = new MenuItem("Bicycle Advance","/wap/ppms/loans/rptApplications.aspx?mode=B"));tmp.mnemonic = '';mG25.add(tmp = new MenuItem("Motor Car/Scooter Advance","/wap/ppms/loans/rptApplications.aspx?mode=C"));tmp.mnemonic = '';mG25.add(tmp = new MenuItem("Festival Advance","/wap/ppms/loans/rptApplications.aspx?mode=F"));tmp.mnemonic = '';mG25.add(tmp = new MenuItem("House Loans","/wap/ppms/loans/rptApplications.aspx?mode=H"));tmp.mnemonic = '';mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL04.add(tmp = new MenuItem("Add","/wap/ppms/leave/leaveApplicationform.aspx?mode=add&task_id=L05"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/wap/ppms/leave/DeletLeaveApplication.aspx?mode=delete"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Application Printing","/wap/ppms/Reports/formats/ApplicationForms/rptLeaveApplication.aspx?mode=rptLeaveApplication"));tmp.mnemonic = '';mP22.add(tmp = new MenuItem("Add","/wap/ppms/employee/reimbursementOfTutionFee.aspx?mode=add"));tmp.mnemonic = '';mQ001.add(tmp = new MenuItem("Entry",null,null, mQ002) );
tmp.mnemonic = ' ';
mQ001.add(tmp = new MenuItem("Print","/wap/ppms/QuarterAllotment/QuarAllotRept.aspx"));tmp.mnemonic = ' ';mQ002.add(tmp = new MenuItem("Add","/wap/ppms/quarters/quarterApplication.aspx?mode=add"));tmp.mnemonic = ' ';mQ002.add(tmp = new MenuItem("Edit","/wap/ppms/quarters/quarterApplication.aspx?mode=edit"));tmp.mnemonic = ' ';mQ002.add(tmp = new MenuItem("Delete","/wap/ppms/quarters/quarterApplication.aspx?mode=delete"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Employee", mP01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Govt.Loans", mG00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("POST T.A./CONVAYANCE", mT80) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Provident Fund", mF00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Quarters", mQ00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Settlement", mY03) );
tmp.mnemonic = '';

menuBar.write();