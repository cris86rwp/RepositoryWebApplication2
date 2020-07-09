Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mY01= new Menu();var mY00= new Menu();var mY02= new Menu();var mZ02= new Menu();var mY100= new Menu();var mY10= new Menu();var mZ12= new Menu();var mZ27= new Menu();
var tmp;
mY00.add(tmp = new MenuItem("DA/NDA rate change","/ppms/DAArrears/daNdaRateChange.aspx"));tmp.mnemonic = '';mY00.add(tmp = new MenuItem("DA Arr.File creation","/ppms/DAArrears/DAFileCreation.aspx"));tmp.mnemonic = '';mY00.add(tmp = new MenuItem("ModifyDA Arrears File",null,null, mY100) );
tmp.mnemonic = '';
mY00.add(tmp = new MenuItem("DA Related Calculation","/ppms/daarrears/darrearscalculation.aspx"));tmp.mnemonic = '';mY00.add(tmp = new MenuItem("DA Arrears CheckList","/ppms/DAArrears/DAArr.Rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mY00.add(tmp = new MenuItem("Post DA Arrears to Payroll","/ppms/DAArrears/postDaToSupplPayroll.aspx?post=P"));tmp.mnemonic = '';mY00.add(tmp = new MenuItem("Post DA Arr to Supp Bill (All Cash)","/ppms/DAArrears/postDaToSupplPayroll.aspx?post=S"));tmp.mnemonic = '';mY00.add(tmp = new MenuItem("Ret./Exp.DA to Suppl.","/ppms/DAArrears/retiredDaToSuppl.aspx"));tmp.mnemonic = '';mY01.add(tmp = new MenuItem("Bank wise Employees Count","/ppms/plb/bonus_bankwise.rpt?user0=report&password0=report"));tmp.mnemonic = '';mY01.add(tmp = new MenuItem("Modify Bonus Details",null,null, mY10) );
tmp.mnemonic = '';
mY01.add(tmp = new MenuItem("PLB Print","/ppms/plb/bonus_details.rpt?user0=wap&password0=wap"));tmp.mnemonic = ' ';mY01.add(tmp = new MenuItem("PLB Print For Particular Empl.","/ppms/plb/bonus_details_emp.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mY01.add(tmp = new MenuItem("VPF-Contribution","/ppms/plb/vpfContibution.aspx"));tmp.mnemonic = ' ';mY01.add(tmp = new MenuItem("Post to Suppl./Payroll","/ppms/plb/postBnsSupplemetary.aspx"));tmp.mnemonic = ' ';mY02.add(tmp = new MenuItem("IT Related E/D Check List","/ppms/PPIT02"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Add IT Related E/Ds","/ppms/it/incomeTaRelatedEDMaintenance.aspx?mode=add"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Modify IT Related E/Ds","/ppms/it/incomeTaRelatedEDMaintenance.aspx?mode=edit"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Income Tax Calc./Printing","/ppms/it/itprocess.aspx"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("IT Statement Printing BU wise","/ppms/it/ItBUprinting.aspx"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Form 16 File creation","/ppms/it/form16FileCreation.aspx"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Income Tax Form 16  Print","/ppms/Reports/Formats/rptIT/frmForm16Report.aspx"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Form 24 File creation","/ppms/it/form24FileCreation.aspx"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Form24 Report","/ppms/it/form24.rpt?user0=report&password0=report&user0@form24_1.rpt=report&password0@form24_1.rpt=report"));tmp.mnemonic = ' ';mY02.add(tmp = new MenuItem("Income Tax Report /amount wise","/ppms/it/incometax_individual.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mY02.add(tmp = new MenuItem("Pan Data Entry","/ppms/it/panno.aspx"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("February Updations","/ppms/it/itprocess_for_feb.aspx"));tmp.mnemonic = '';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Check List",null,null, mZ27) );
tmp.mnemonic = '';
mY10.add(tmp = new MenuItem("Edit","/ppms/plb/modifyBasicRate.aspx?mode=edit"));tmp.mnemonic = '';mY10.add(tmp = new MenuItem("View","/ppms/plb/modifyBasicRate.aspx?mode=view"));tmp.mnemonic = '';mY100.add(tmp = new MenuItem("Edit","/ppms/DAArrears/modifyDA.aspx?mode=edit"));tmp.mnemonic = '';mY100.add(tmp = new MenuItem("View","/ppms/DAArrears/modifyDA.aspx?mode=view"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("CheckListAwardDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistAwardDetails"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Bonus", mY01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("DA Arrears", mY00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Income Tax", mY02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';

menuBar.write();
