Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mPF01= new Menu();var mP01= new Menu();var mF00= new Menu();var mF06= new Menu();var mF11= new Menu();var mF37= new Menu();var mP101= new Menu();
var tmp;
mF00.add(tmp = new MenuItem("PF Final Withdrawals",null,null, mF06) );
tmp.mnemonic = '';
mF00.add(tmp = new MenuItem("PF Temporary Withdrawal",null,null, mF11) );
tmp.mnemonic = '';
mF00.add(tmp = new MenuItem("PF Sanctioning",null,null, mF37) );
tmp.mnemonic = '';
mF00.add(tmp = new MenuItem("Application Prints","/ppms/Reports/Formats/rptPF/pfPrintApplications.aspx"));tmp.mnemonic = '';mF00.add(tmp = new MenuItem("PFNotingSanctionPrints","/ppms/Reports/Formats/rptPF/pfSanctionPrints.aspx"));tmp.mnemonic = '';mF00.add(tmp = new MenuItem("PF Final Settlement","/ppms/pf/pf_Final_Settlement.aspx?mode=post"));tmp.mnemonic = '';mP01.add(tmp = new MenuItem("View Brief Details",null,null, mP101) );
tmp.mnemonic = ' ';
mPF01.add(tmp = new MenuItem("View PF Login","/ppms/reports/formats/rptQuest/pfLogonDetails.aspx"));tmp.mnemonic = ' ';mF06.add(tmp = new MenuItem("PF Withdrawal - Marriage","/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F38"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("PF Withdrawal - Medical","/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F39"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("PF Withdrawal - HBA","/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F40"));tmp.mnemonic = '';mF06.add(tmp = new MenuItem("Pf Withdrawal - Others","/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F41"));tmp.mnemonic = '';mF11.add(tmp = new MenuItem("PF Withdrawal - Temporary","/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=F42"));tmp.mnemonic = '';mF37.add(tmp = new MenuItem("PF Withdrawal-Marriage","/ppms/pf/applicationForFinalWithdrawalFrom PFForMeetingTheBetrothalMarriageExpenses.aspx?mode=post"));tmp.mnemonic = '';mF37.add(tmp = new MenuItem("PF Withdrawal-Medical","/ppms/pf/applicationForFinalWithdrawalFromPFForMedicalExpenses.aspx?mode=post"));tmp.mnemonic = '';mF37.add(tmp = new MenuItem("PF Withdrawal-HBA","/ppms/pf/applicationForFinalWithdrawalOf PFMoneyForPurchaseOfHouse.aspx?mode=post"));tmp.mnemonic = '';mF37.add(tmp = new MenuItem("PF Withdrawal-Others","/ppms/pf/applicationForFinalWithdrawalOfPfForOthers.aspx?mode=post"));tmp.mnemonic = '';mF37.add(tmp = new MenuItem("PF Withdrawal-Temporary","/ppms/pf/applicationForTemporaryAdvanceWithdrawalFromPFDeposit.aspx?mode=post"));tmp.mnemonic = '';mP101.add(tmp = new MenuItem("On Code","/ppms/employee/EmployeeDetailsOnCode.aspx"));tmp.mnemonic = ' ';mP101.add(tmp = new MenuItem("On Name","/ppms/employee/EmployeeDetailsOnName.aspx"));tmp.mnemonic = ' ';mP101.add(tmp = new MenuItem("Special Search","/ppms/employee/frmEmpDetails.aspx"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("PF Login", mPF01) );
tmp.mnemonic = ' ';
menuBar.add( tmp = new MenuButton("Employee", mP01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Provident Fund", mF00) );
tmp.mnemonic = '';

menuBar.write();
