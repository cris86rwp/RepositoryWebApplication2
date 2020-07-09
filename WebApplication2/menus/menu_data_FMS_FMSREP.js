Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var m002= new Menu();var m004= new Menu();var m145= new Menu();var m299= new Menu();var m105= new Menu();var m111= new Menu();var m322= new Menu();var m323= new Menu();var m300= new Menu();
var tmp;
m002 .add(tmp = new MenuItem("Cheques",null,null, m145) );
tmp.mnemonic = ' ';
m002 .add(tmp = new MenuItem("Transfer Certificate",null,null, m299) );
tmp.mnemonic = ' ';
m004 .add(tmp = new MenuItem("Transaction Checklist","/ppms/fms/Reports/frmworkTranList.aspx?rptName=rptWorksTranCheckList.rpt"));tmp.mnemonic = ' ';m004 .add(tmp = new MenuItem("Works Register","/ppms/fms/Reports/frmPrintWorksRegister.aspx"));tmp.mnemonic = ' ';m004 .add(tmp = new MenuItem("Work-wise Expenditure","/ppms/fms/Reports/frmworkTranList.aspx?rptName=rptwDeptWiseExpenditure.rpt"));tmp.mnemonic = ' ';m004 .add(tmp = new MenuItem("Daily Cash book",null,null, m105) );
tmp.mnemonic = ' ';
m004 .add(tmp = new MenuItem("Monthly Reports",null,null, m111) );
tmp.mnemonic = ' ';
m105 .add(tmp = new MenuItem("Generate Cash Book","/ppms/fms/reports/dailycashbook.aspx?mpara=C"));tmp.mnemonic = ' ';m105 .add(tmp = new MenuItem("Generate Cash Outgo","/ppms/fms/reports/cashoutgo.aspx"));tmp.mnemonic = ' ';m105 .add(tmp = new MenuItem("Print Daily Expense Book","/ppms/fms/reports/printDailyExpenses.aspx"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("JV Book","/ppms/fms/reports/dailycashbook1.aspx?mpara=J"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Combined Journal","/ppms/fms/Reports/frmreptBookLedgerJournal.aspx?para=J&rptName=book_combined_journal.rpt"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Account Current List","/ppms/fms/Reports/acccurrlist.aspx?mpara=L"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Account Current","/ppms/fms/Reports/acccurrlist.aspx?mpara=A"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Suspense Heads","/ppms/fms/reports/dbcrUnderCaptial.aspx"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Loans","/ppms/fms/Reports/frmReptCashLoan.aspx?para=B"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("K-Deposits","/ppms/fms/reports/kdeposits.aspx"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Loans(approximate)","/ppms/fms/Reports/frmReptCashLoan.aspx?para=A"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Civil Heads","/ppms/fms/reports/civilheads.aspx"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Insurance","/ppms/fms/reports/insurancesch.aspx"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Income Tax","/ppms/fms/reports/taxes.aspx"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Transfer Debits","/ppms/fms/Reports/frmReptScheduleofTransactions.aspx?para=D&rptName=rptTransDebit.rpt"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Transfer Credits","/ppms/fms/Reports/frmReptScheduleofTransactions.aspx?para=C&rptName=rptTransCredit.rpt"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Annexure A","/ppms/fms/reports/annexure.aspx?choice=A"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("General Ledger","/ppms/fms/Reports/frmreptBookLedgerJournal.aspx?para=G&rptName=book_general_ledger.rpt"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Apx Acc Cur List","/ppms/fms/Reports/approxacccurrlist.aspx?mpara=L"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Aprox Account Current","/ppms/fms/Reports/approxacccurrlist.aspx?mpara=A"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Annexure_A(Approx)","/ppms/fms/reports/annexure.aspx?choice=R"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Misc Cash Receipts","/ppms/fms/FMRMMCR"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Cash Outgo-(Monthly)","/ppms/fms/Reports/frmrptBookCashOutGo.aspx?rptName=book_cash_outgo.rpt"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Purchase Grant","/ppms/fms/Reports/rpt_generation_print.axpx?mode=PG"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("PCDO (Budget)","/ppms/fms/FMRBUD"));tmp.mnemonic = ' ';m111 .add(tmp = new MenuItem("Distribution of Actual Exp.","/ppms/fms/Reports/formats/rpt_generation_print.axpx?mode=AE"));tmp.mnemonic = ' ';m145 .add(tmp = new MenuItem("Cheque Statement","/ppms/fms/reports/rptChequeStatement.aspx"));tmp.mnemonic = ' ';m299 .add(tmp = new MenuItem("Inward TC",null,null, m322) );
tmp.mnemonic = ' ';
m299 .add(tmp = new MenuItem("Outward TC",null,null, m323) );
tmp.mnemonic = ' ';
m322 .add(tmp = new MenuItem("Inward TC(Books)",null,null, m300) );
tmp.mnemonic = ' ';
m323 .add(tmp = new MenuItem("Register","/ppms/fms/reports/tcOutwardRegister.aspx"));tmp.mnemonic = ' ';m323 .add(tmp = new MenuItem("Print certificate","/ppms/fms/reports/rptOutwardTcPrint.aspx?rptName=rptOutwardsPrintTC.rpt"));tmp.mnemonic = ' ';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Transactions", m002) );
tmp.mnemonic = ' ';
menuBar.add( tmp = new MenuButton("Reports", m004) );
tmp.mnemonic = ' ';

menuBar.write();
