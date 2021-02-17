$(document).ready(function () {
    $('#submit').click(function () {
        $('#error').html("");
        $('#ok').html("");
        var username = $("input[name=usrnm]").val().trim();
        var email = $("input[name=email]").val().trim();
        var password = $("input[name=psw]").val().trim();
        var repeatPassword = $("input[name=psw1]").val().trim();
        if (username == "" || email == "" || password == "" || repeatPassword == "") {
            $('#error').html('Please fill  all Fields!');
        } 
        else if (username.length < 6) {
            $('#error').html('Username is too short!');
        }
        else if (password.length < 6) {
            $('#error').html('Password is too short!');
            resetPassword();
        }
        else if (password != repeatPassword) {
            $('#error').html('Password Do Not Match!');
            resetPassword();
        }
       
        else {
            $.ajax({
                url: "/User/Registration",
                method: "Post",
                data: { "Username": username, "Email": email, "Password": password, "RepeatPassword": repeatPassword },
                success: function (response)
                {
                    if (response == "ok") {
                        $('#ok').html('Registered Successfully!');
                        resetInfo();
                    }
                    if (response == "UserNameFalse") {
                        $('#error').html('Username already Used!');
                        resetUsername();
                    }
                    if (response == "InvalidEmail!") {
                        $('#error').html('Email already Used!');
                        resetEmail();
                    }
                    
                },
                error: function ()
                {
                    alert("Please contact system administrator!");
       
                }
            });
        }
        
    });
    function resetInfo() {
        $('input[name=usrnm]').val("");
        $('input[name=email]').val("");
        $('input[name=psw]').val("");
        $('input[name=psw1]').val("");
    }
    function resetUsername() {
        $('input[name=usrnm]').val("");
    }
    function resetEmail() {
        $('input[name=email]').val("");
    }
    function resetPassword() {
        $('input[name=psw]').val("");
        $('input[name=psw1]').val("");
    }

    $('#submitReg').click(function () {
        $("#Reg").slideDown(1000);
        $("#Login").slideUp(1000);
    });

    $('#submit1').click(function () {
        $("#Reg").slideUp(1000);
        $("#Login").slideDown(1000);
    });

    $('#submitLog').click(function () {
        $('#error').html("");
        $('#ok').html("");
        var username = $('input[name=usrnmLog]').val().trim();
        var password = $('input[name=pswLog]').val().trim();
        if (username == "" || password == "") {
            $('#error').html('Please fill  all Fields!');
        }
        else if(username.length < 6 || password.length < 6) {
            $('#error').html('Username or password is incorrect!');
        }
       
    });

    $('#submitProf').click(function () {
        var name = $('#nam').val().trim();
        var surname = $('#sur').val().trim();
        var age = $('#age').val().trim();
        var gender = $('#gender').val().trim();
        var userId = $('#e').val().trim();
        if (name == "" || surname == "" || age == null || gender == null) {
            $('#errorProf').html("Please Fill All Fields and Then Submit!");
        }
        else if (age <= 0) {
            $('#errorProf').html("Please Enter Valid Age");
            resetAge();
        }
        else if (gender < 1 || gender > 2) {
            $('#errorProf').html("Please Enter Valid Gender(1:Female or 2:Male)");
            resetGender();
        }
        else {
             $.ajax({
                url: "/User/AddFirstDetails",
                method: "Post",
                data: { "Name": name, "Surname": surname, "Age": age, "Gender": gender , "UserId": userId},
                success: function () {
                    alert("Successfully Saved!");
                },
                error: function () {
                    alert("Please Contact System Administrator!");
                },
             });
            resetAllInfo();
            $('#errorProf').html("");
        }
     
    });
    function resetAllInfo() {
        $('input[name=Name]').val("");
        $('input[name=Surname]').val("");
        $('input[name=Age]').val("");
        $('input[name=Gender]').val("");
    }
    function resetAge() {
        $('input[name=Age]').val("");
    }
    function resetGender() {
        $('input[name=Gender]').val("");
    }
});