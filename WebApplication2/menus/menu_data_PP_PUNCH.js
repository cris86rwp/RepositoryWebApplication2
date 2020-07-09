Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mL02= new Menu();var mO01= new Menu();var mL03= new Menu();var mL50= new Menu();var mL04= new Menu();
var tmp;
mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave/Absence",null,null, mL50) );
tmp.mnemonic = '';
mO01.add(tmp = new MenuItem("Enter OT Bookings","/ppms/ot/NonPunchOTBookingEntry.aspx?mode=add"));tmp.mnemonic = '';mO01.add(tmp = new MenuItem("Delete OT Bookings","/ppms/ot/NonPunchOTBookingDeletion.aspx?mode=delete"));tmp.mnemonic = '';mO01.add(tmp = new MenuItem("View OT Bookings","/ppms/ot/NonPunchOTBookingQuery.aspx"));tmp.mnemonic = '';mO01.add(tmp = new MenuItem("OT Bookings List","/ppms/ot/overTimeCheckList.aspx"));tmp.mnemonic = '';mO01.add(tmp = new MenuItem("Calculate NOT/FOT","/ppms/ot/calculateNotFot.aspx"));tmp.mnemonic = '';mO01.add(tmp = new MenuItem("OT Statement","/ppms/ot/overTimeStatement.aspx"));tmp.mnemonic = '';mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL03.add(tmp = new MenuItem("Posting Leave Sanction","/ppms/leave/postSanctionToApplicationForLeave.aspx?mode=post"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Add","/ppms/leave/leaveApplication.aspx?mode=add&task_id=L05"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave.aspx?mode=delete"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Application Printing","/ppms/Reports/formats/ApplicationForms/rptLeaveApplication.aspx?mode=rptLeaveApplication"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("GenerateMemorandum","/ppms/leave/leaveMemorandum.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memorandum","/ppms/leave/rptLeaveMemorandum.aspx?mode=memorandum"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("CheckList(Leave posting)","/ppms/Reports/formats/leave/leavePostingCheckList.aspx?mode=leaveAbsenseCheckList.rpt"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Account Statement","/ppms/leave/frmLeaveAnnualStatement.aspx?mode=employee"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memo Bill unit","/ppms/Reports/formats/leave/FrmLVbuEmp.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Query","/ppms/leave/leaveQuery.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Over Time", mO01) );
tmp.mnemonic = '';

menuBar.write();
