Module Module1

    Sub Main()
        Dim yearOfExpiry, monthOfExpiry, amountToWithdraw, amountDeposited, userChoice, month, year As Integer
        Dim userChoice2 As String
        Dim currentDate As DateTime = DateTime.Now
        Dim rnd As New Random
        Dim accountBalance As Integer
        month = currentDate.Month
        year = currentDate.Year
        Dim maxAccounts As Integer = 10
        Dim accountNumbers(maxAccounts - 1) As String
        Dim accountAmounts(maxAccounts - 1) As Integer
        Dim numAccounts As Integer = 0

        While True
            Console.WriteLine("Enter your account number (or type 'exit' to quit)...")
            Dim accountNumber As String = Console.ReadLine()
            userChoice = 0

            If accountNumber.ToLower() = "exit" Then
                Exit While
            End If

            Console.WriteLine("Please input the year of expiry for your card...")
            yearOfExpiry = Console.ReadLine()
            If yearOfExpiry < year Then
                Console.WriteLine("Card is not valid...")
                Console.WriteLine("Please insert a valid card...")
                Exit Sub
            ElseIf yearOfExpiry > year Then
                Console.WriteLine("Card is valid...")
            ElseIf yearOfExpiry = year Then
                Console.WriteLine("Please enter the month of expiry for your card as a number...")
                monthOfExpiry = Console.ReadLine()
                If monthOfExpiry < month Then
                    Console.WriteLine("Card is not valid...")
                    Console.WriteLine("Please insert a valid card...")
                    Exit Sub
                ElseIf monthOfExpiry >= month Then
                    Console.WriteLine("Card is valid...")
                End If
            End If

            Dim existingIndex As Integer = -1
            For i As Integer = 0 To numAccounts - 1
                If accountNumbers(i) = accountNumber Then
                    existingIndex = i
                    Exit For
                End If
            Next

            If existingIndex >= 0 Then
                accountBalance = accountAmounts(existingIndex)
                While userChoice <> 4
                    Console.WriteLine("1: Display balance...   2: Withdraw funds...   3: Deposit funds...   4: Return card...   Pick one option...")
                    userChoice = Console.ReadLine()
                    If userChoice = 1 Then
                        Console.WriteLine("Your balance is £" & accountBalance & "...")
                    ElseIf userChoice = 2 Then
                        Console.WriteLine("In whole Erician Pounds, please input how much money would you like as just a number...")
                        amountToWithdraw = Console.ReadLine()
                        If amountToWithdraw > accountBalance Then
                            Console.WriteLine("You are asking to withdraw more than you have...")
                        ElseIf amountToWithdraw = accountBalance Then
                            Console.WriteLine("If you withdraw this amount of money you will be left with £0 left... If you want to continue then send Y... Any other input will be taken as not wanting to continue...")
                            userChoice2 = Console.ReadLine()
                            If userChoice2.ToUpper = "Y" Then
                                accountBalance = accountBalance - amountToWithdraw
                                Console.WriteLine("You have successfully withdrawn £" & amountToWithdraw & "... Your new balance is £" & accountBalance & "...")
                            Else
                                Console.WriteLine("You have successfully left the process...")
                            End If
                        Else
                            accountAmounts(existingIndex) = accountAmounts(existingIndex) - amountToWithdraw
                            Console.WriteLine("You have successfully withdrawn £" & amountToWithdraw & "... Your new balance is £" & accountBalance & "...")
                        End If
                    ElseIf userChoice = 3 Then
                        Console.WriteLine("Please input how much money you would like to deposit in whole Erician pounds...")
                        amountDeposited = Console.ReadLine()
                        accountBalance = accountBalance + amountDeposited
                        Console.WriteLine("Your new balance is £" & accountBalance & "...")
                    End If
                End While
            Else
                accountBalance = rnd.Next(0, 10001)
                accountNumbers(numAccounts) = accountNumber
                accountAmounts(numAccounts) = accountBalance
                numAccounts += 1
                While userChoice <> 4
                    Console.WriteLine("1: Display balance...   2: Withdraw funds...   3: Deposit funds...   4: Return card...   Pick one option...")
                    userChoice = Console.ReadLine()
                    If userChoice = 1 Then
                        Console.WriteLine("Your balance is £" & accountBalance & "...")
                    ElseIf userChoice = 2 Then
                        Console.WriteLine("In whole Erician Pounds, please input how much money would you like as just a number...")
                        amountToWithdraw = Console.ReadLine()
                        If amountToWithdraw > accountBalance Then
                            Console.WriteLine("You are asking to withdraw more than you have...")
                        ElseIf amountToWithdraw = accountBalance Then
                            Console.WriteLine("If you withdraw this amount of money you will be left with £0 left... If you want to continue then send Y... Any other input will be taken as not wanting to continue...")
                            userChoice2 = Console.ReadLine()
                            If userChoice2.ToUpper = "Y" Then
                                accountBalance = accountBalance - amountToWithdraw
                                Console.WriteLine("You have successfully withdrawn £" & amountToWithdraw & "... Your new balance is £" & accountBalance & "...")
                            Else
                                Console.WriteLine("You have successfully left the process...")
                            End If
                        Else
                            accountBalance = accountBalance - amountToWithdraw
                            Console.WriteLine("You have successfully withdrawn £" & amountToWithdraw & "... Your new balance is £" & accountBalance & "...")
                        End If
                    ElseIf userChoice = 3 Then
                        Console.WriteLine("Please input how much money you would like to deposit in whole Erician pounds...")
                        amountDeposited = Console.ReadLine()
                        accountBalance = accountBalance + amountDeposited
                        Console.WriteLine("Your new balance is £" & accountBalance & "...")
                    End If
                End While
            End If
            Console.WriteLine("Thank you for using our ATM and goodbye... Press the 'Enter' key to carry on...")
            Console.ReadLine()
            Console.Clear()
        End While

        Console.WriteLine("Thank you for using this program and goodbye...")
        Console.ReadLine() ' Keep the console window open
    End Sub
End Module
