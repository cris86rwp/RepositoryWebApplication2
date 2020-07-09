Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mI02= new Menu();var mZ02= new Menu();var mZ12= new Menu();
var tmp;
mI02.add(tmp = new MenuItem("INC 03","/ppms/Reports/Formats/rptIncentive/ppinc031.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("IB Rates Summary Report","/ppms/Reports/Formats/rptIncentive/ibRatesSummary.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("IB Earnings Summary","/ppms/Reports/Formats/rptIncentive/ibEarningSummary.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("GA/OT Summary","/ppms/Reports/Formats/rptIncentive/incentiveGA_OTHours.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("GA/OT Hours Emp. Wise","/ppms/Reports/Formats/rptIncentive/incentiveGA_OTHrsEmployeeWise.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Incentive Bill","/ppms/Reports/Formats/rptIncentive/ppinc091.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Skill Code Difference","/ppms/Reports/Formats/rptIncentive/employeesWithDifSkillCodesaspx.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Group wise Emp Summary","/ppms/Reports/Formats/rptIncentive/incemp.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Incentive List for SSEs and SEs","/ppms/incentives/frmIncentiveArrearsSuperwisers.aspx"));tmp.mnemonic = ' ';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Incentive Reprots","/ppms/Reports/Formats/rptIncentive/hr_Incentive_Reports.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Incentive", mI02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';

menuBar.write();
