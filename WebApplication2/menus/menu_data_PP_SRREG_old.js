Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mD00= new Menu();var mD24= new Menu();var mD05= new Menu();var mD01= new Menu();var mD02= new Menu();var mD03= new Menu();var mD32= new Menu();var mD38= new Menu();
var tmp;
mD00.add(tmp = new MenuItem("Punishments",null,null, mD01) );
tmp.mnemonic = '';
mD00.add(tmp = new MenuItem("Awards",null,null, mD02) );
tmp.mnemonic = '';
mD00.add(tmp = new MenuItem("Training",null,null, mD03) );
tmp.mnemonic = '';
mD00.add(tmp = new MenuItem("Court Attachment",null,null, mD32) );
tmp.mnemonic = '';
mD00.add(tmp = new MenuItem("Selection Board",null,null, mD38) );
tmp.mnemonic = '';
mD05.add(tmp = new MenuItem("Print Service Record","/ppms/others/ServiceRegister.aspx"));tmp.mnemonic = '';mD24.add(tmp = new MenuItem("Bio Data(Oth.Particulars)","/ppms//employee/biodataDetails.aspx?mode=add"));tmp.mnemonic = '';mD24.add(tmp = new MenuItem("Qualification","/ppms//employee/employeeFamily.aspx?mode=edit"));tmp.mnemonic = '';mD24.add(tmp = new MenuItem("QPS Maint.","/ppms/PPQP02"));tmp.mnemonic = '';mD24.add(tmp = new MenuItem("Medical Test","/ppms/PPMT01"));tmp.mnemonic = '';mD01.add(tmp = new MenuItem("Entry","/ppms//directEntry/punishmentDetails.aspx?mode=add"));tmp.mnemonic = '';mD01.add(tmp = new MenuItem("Edit","/ppms//directEntry/punishmentDetails.aspx?mode=edit"));tmp.mnemonic = '';mD01.add(tmp = new MenuItem("Delete","/ppms//directEntry/punishmentDetails.aspx?mode=delete"));tmp.mnemonic = '';mD01.add(tmp = new MenuItem("View","/ppms//directEntry/punishmentDetails.aspx?mode=view"));tmp.mnemonic = '';mD02.add(tmp = new MenuItem("Entry","/ppms//directEntry/awardDirect.aspx?mode=add"));tmp.mnemonic = '';mD02.add(tmp = new MenuItem("Edit","/ppms//directEntry/awardDirect.aspx?mode=edit"));tmp.mnemonic = '';mD02.add(tmp = new MenuItem("Delete","/ppms//directEntry/awardDirect.aspx?mode=delete"));tmp.mnemonic = '';mD02.add(tmp = new MenuItem("View","/ppms//directEntry/awardDirect.aspx?mode=view"));tmp.mnemonic = '';mD03.add(tmp = new MenuItem("Entry","/ppms/PPTRDIR"));tmp.mnemonic = '';mD03.add(tmp = new MenuItem("Edit","/ppms/PPTRDIR"));tmp.mnemonic = '';mD03.add(tmp = new MenuItem("Delete","/ppms/PPTRDIR"));tmp.mnemonic = '';mD03.add(tmp = new MenuItem("View","/ppms/PPTRDIR"));tmp.mnemonic = '';mD32.add(tmp = new MenuItem("Entry","/ppms/directEntry/courtAttachmentDetails.aspx?mode=add"));tmp.mnemonic = '';mD32.add(tmp = new MenuItem("Edit","/ppms/directEntry/courtAttachmentDetails.aspx?mode=edit"));tmp.mnemonic = '';mD32.add(tmp = new MenuItem("Delete","/ppms/directEntry/courtAttachmentDetails.aspx?mode=delete"));tmp.mnemonic = '';mD32.add(tmp = new MenuItem("View","/ppms/directEntry/courtAttachmentDetails.aspx?mode=view"));tmp.mnemonic = '';mD38.add(tmp = new MenuItem("Entry","/ppms//directEntry/selectionBoardResult.aspx?mode=add"));tmp.mnemonic = '';mD38.add(tmp = new MenuItem("Edit","/ppms//directEntry/selectionBoardResult.aspx?mode=edit"));tmp.mnemonic = '';mD38.add(tmp = new MenuItem("Delete","/ppms//directEntry/selectionBoardResult.aspx?mode=delete"));tmp.mnemonic = '';mD38.add(tmp = new MenuItem("View","/ppms//directEntry/selectionBoardResult.aspx?mode=view"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Direct Entry", mD00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Others", mD24) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Service Record", mD05) );
tmp.mnemonic = '';

menuBar.write();
