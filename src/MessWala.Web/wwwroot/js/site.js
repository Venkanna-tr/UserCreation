// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$("#login").click(function () {
    debugger;
    isvalidate = true;
    var user = $("#userid").val();
    var password = $("#pwd").val();
    // Checking for blank fields.
    // var validate = ['userid', 'pwd']
    // for (i = 0; i < validate.length; i++) {
    //     debugger;
    //     if ($('#' + validate[i]).val() == '') {
    //         $('#' + validate[i].css({ "border": "1px solid red" }))
    //         isvalidate = false;
    //         return false;
    //     } else {
    //         $('#' + validate[i]).css({ "border": "" })
    //     }
    // }
    if (user == '' || password == '') {
        $('input[type="text"],input[type="password"]').css("border", "1px solid red");
        return false;
    }
});
