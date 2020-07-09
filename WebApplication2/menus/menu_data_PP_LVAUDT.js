Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mL02= new Menu();var mL03= new Menu();var mL50= new Menu();var mL04= new Menu();
var tmp;
mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave/Absence",null,null, mL50) );
tmp.mnemonic = '';
mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL04.add(tmp = new MenuItem("Cancel Leave","/ppms/leave/editApplicationForLeave.aspx?mode=cancel"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave.aspx?mode=delete"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("GenerateMemorandum","/ppms/leave/leaveMemorandum.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Special Credit","/ppms/leave//leaveSpecialDeditCredit.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memorandum","/ppms/leave/rptLeaveMemorandum.aspx?mode=memorandum"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("CheckList(Leave posting)","/ppms/Reports/formats/leave/leavePostingCheckList.aspx?mode=leaveAbsenseCheckList.rpt"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memo Bill unit","/ppms/Reports/formats/leave/FrmLVbuEmp.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Retrospective Posting","/ppms/leave/leaveRetrospectivePosting.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Query","/ppms/leave/leaveQuery.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';

menuBar.write();
