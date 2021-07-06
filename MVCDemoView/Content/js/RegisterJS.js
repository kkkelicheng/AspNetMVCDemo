//检查用户名
$(function () {
    var result = false;

    $("#Account").blur(function () {
        var account = $(this);
        if (account.val() == "") {
            account.removeClass("input_success").addClass("input_error");
            result = false;
            $("#op_account").css("color", "red").html("用户名不能为空")
            return;
        }

        //如何判断用户名重名
        //1.去服务端查找数据
        $.ajax({
            url: "looklookUserName",  //这里路径ajax会去controller进行匹配，请看User的controller,why?
            data: { "account": account.val() },
            type: "POST",  //默认是 get
            dataType: "text",  //如果不填，会根据mimetype进行判断，可以是json
            success: function (dataResult) {
                alert("ajax success dataResult:" + dataResult);
                if (dataResult == "1") {
                    $("#op_account").css("color", "red").html("用户名已经存在");
                    result = false;
                }
                else {
                    result = true;
                }
            },
            async: false, //默认是 async的
            error: function (msg) {
                alert("ajax failed msg:" + msg);
            }
        });
        alert("ajax out");
        if (result) {
            alert("ajax out" + result);
            account.removeClass("input_error").addClass("input_success");
            $("#op_account").css("color", "green").html("验证通过！")
        }
        else {
            account.removeClass("input_success").addClass("input_error");
            $("#op_account").css("color", "red").html("验证不通过")
        }
    });



    //重写提交按钮事件,返回true就会去提交刷新页面，返回false不会提交，原来的信息还在
    $("#btnSubmit").click(function myfunction() {
        //这里打印一下爱好是不是选择的时候
        $("input[name='Hobby']").each(function () {
            //alert(this.checked);
        });

        return result;
    });
})