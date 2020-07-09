Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var m_00= new Menu();var mI02= new Menu();var mZ02= new Menu();var m_01= new Menu();var mIC13= new Menu();var mI05= new Menu();var mI06= new Menu();var mZ12= new Menu();var m_20= new Menu();var m_21= new Menu();
var tmp;
m_00.add(tmp = new MenuItem("General Codes",null,null, m_01) );
tmp.mnemonic = '';
mI02.add(tmp = new MenuItem("Incentive Calender",null,null, mIC13) );
tmp.mnemonic = ' ';
mI02.add(tmp = new MenuItem("Production Details",null,null, mI05) );
tmp.mnemonic = '';
mI02.add(tmp = new MenuItem("Idle Hours details",null,null, mI06) );
tmp.mnemonic = '';
mI02.add(tmp = new MenuItem("INC 03","/ppms/Reports/Formats/rptIncentive/ppinc031.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("IB Rates Summary Report","/ppms/Reports/Formats/rptIncentive/ibRatesSummary.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("IB Earnings Summary","/ppms/Reports/Formats/rptIncentive/ibEarningSummary.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("GA/OT Summary","/ppms/Reports/Formats/rptIncentive/incentiveGA_OTHours.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("GA/OT Hours Emp. Wise","/ppms/Reports/Formats/rptIncentive/incentiveGA_OTHrsEmployeeWise.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Incentive Bill","/ppms/Reports/Formats/rptIncentive/ppinc091.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Skill Code Difference","/ppms/Reports/Formats/rptIncentive/employeesWithDifSkillCodesaspx.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Group wise Emp Summary","/ppms/Reports/Formats/rptIncentive/incemp.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Incentive List for SSEs and SEs","/ppms/incentives/frmIncentiveArrearsSuperwisers.aspx"));tmp.mnemonic = ' ';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Incentive Reprots","/ppms/Reports/Formats/rptIncentive/hr_Incentive_Reports.aspx"));tmp.mnemonic = '';m_01.add(tmp = new MenuItem("Code Type Maintenance",null,null, m_20) );
tmp.mnemonic = '';
m_01.add(tmp = new MenuItem("Code Maintenance",null,null, m_21) );
tmp.mnemonic = '';
mI05.add(tmp = new MenuItem("Add","/ppms/incentives/productionDetailsEntry.aspx?mode=add"));tmp.mnemonic = '';mI05.add(tmp = new MenuItem("Edit","/ppms/incentives/productionDetailsEntry.aspx?mode=edit"));tmp.mnemonic = '';mI05.add(tmp = new MenuItem("Delete","/ppms/incentives/productionDetailsEntry.aspx?mode=delete"));tmp.mnemonic = '';mI05.add(tmp = new MenuItem("View","/ppms/incentives/ProductionDetails.aspx?mode=view"));tmp.mnemonic = '';mI06.add(tmp = new MenuItem("Add","/ppms/incentives/incentiveIdleHours.aspx?mode=add"));tmp.mnemonic = '';mI06.add(tmp = new MenuItem("Edit","/ppms/incentives/incentiveIdleHours.aspx?mode=edit"));tmp.mnemonic = '';mI06.add(tmp = new MenuItem("Delete","/ppms/incentives/incentiveIdleHours.aspx?mode=delete"));tmp.mnemonic = '';mI06.add(tmp = new MenuItem("View","/ppms/incentives/frmIncentiveIdleHoursView.aspx"));tmp.mnemonic = '';mIC13.add(tmp = new MenuItem("Create","/ppms/incentives/sundayHolidayUpdation.aspx?mode=add"));tmp.mnemonic = ' ';mIC13.add(tmp = new MenuItem("Edit","/ppms/incentives/IncentiveCalenderEdit.aspx"));tmp.mnemonic = ' ';m_20.add(tmp = new MenuItem("Add","/ppms/codeTypeMaintenance.aspx?mode=add"));tmp.mnemonic = '';m_20.add(tmp = new MenuItem("Edit","/ppms/codeTypeMaintenance.aspx?mode=edit"));tmp.mnemonic = '';m_21.add(tmp = new MenuItem("Add","/ppms/codeMaintenance.aspx?mode=add"));tmp.mnemonic = '';m_21.add(tmp = new MenuItem("Edit","/ppms/codeMaintenance.aspx?mode=edit"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Setup", m_00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Incentive", mI02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';

menuBar.write();
