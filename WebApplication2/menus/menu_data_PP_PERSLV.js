Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mA02= new Menu();var mL02= new Menu();var mPPR0= new Menu();var mP220= new Menu();var mL03= new Menu();var mL50= new Menu();var mL04= new Menu();
var tmp;
mA02.add(tmp = new MenuItem("Post/Prepone Increments","/ppms/increments/increments.aspx"));tmp.mnemonic = '';mA02.add(tmp = new MenuItem("Sactioned List","/ppms/increments/sanctions.aspx?mode=S"));tmp.mnemonic = '';mA02.add(tmp = new MenuItem("Postponed List","/ppms/increments/sanctions.aspx?mode=P"));tmp.mnemonic = '';mA02.add(tmp = new MenuItem("On Leave","/ppms/increments/frmEmpLeaveONInc.aspx"));tmp.mnemonic = ' ';mA02.add(tmp = new MenuItem("Due List","/ppms/Reports/formats/rptIncrements/rptIncrementDueListPNL.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mA02.add(tmp = new MenuItem("NQS","/ppms/Reports/formats/rptIncrements/nqp_report.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave/Absence",null,null, mL50) );
tmp.mnemonic = '';
mP220.add(tmp = new MenuItem("Add","/ppms/increments/empTmpIncrements.aspx"));tmp.mnemonic = ' ';mPPR0.add(tmp = new MenuItem("View","/ppms/payslip/frmPayslip.aspx"));tmp.mnemonic = ' ';mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL03.add(tmp = new MenuItem("Posting Leave Sanction","/ppms/leave/postSanctionToApplicationForLeave.aspx?mode=post"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Add","/ppms/leave/leaveApplication.aspx?mode=add&task_id=L05"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave.aspx?mode=delete"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Application Printing","/ppms/Reports/formats/ApplicationForms/rptLeaveApplication.aspx?mode=rptLeaveApplication"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("GenerateMemorandum","/ppms/leave/leaveMemorandum.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memorandum","/ppms/leave/rptLeaveMemorandum.aspx?mode=memorandum"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("CheckList(Leave posting)","/ppms/Reports/formats/leave/leavePostingCheckList.aspx?mode=leaveAbsenseCheckList.rpt"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Query","/ppms/leave/leaveQuery.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Increments", mA02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Pay Slip View", mPPR0) );
tmp.mnemonic = ' ';
menuBar.add( tmp = new MenuButton("P Branch Increments", mP220) );
tmp.mnemonic = ' ';

menuBar.write();
