$(function () {
    $.ajax({
        type: 'get',
        url: '../Menu/GetLeftMenuTreeData',
        success: function (data) {
            if (data.stateCode == 200) {
                var html = asideTpl(data.data);
                document.querySelector('#left_menu').innerHTML = html;
                $(".jumpiframe").on('click', function () {
                    var indent = $(this).css('text-indent'),
                        jumpClass = $(this).attr('class');
                    if (/children/.test(jumpClass)) {
                        $(this).next().children('li').children('a').css('text-indent', indent.match(/\d+/g)[0] - 0 + 10 + 'px');
                    }
                })
            }
            if (data.StateCode == 301) {
                $.get("../Login/Index");
            }
        },
        error: function (data) {
            $.get("../Login/Index");
        }
    })


    function asideTpl(res) {
        debugger;
        var tpl = '<ul id="accordion" class="nav nav-sidbar">';
        if (res != null && res.length > 0) {
            res.forEach(function (val) {
                tpl += '<li class="panel"><a data-parent="#accordion" href="javascript:;" data-toggle="collapse" data-url="' + val.Url + '" data-target="#parent-' + val.Guid + '" id="parent-a-' + val.Guid + '" class="parent jumpiframe">'
                    + val.JurName + '</a><ul class="nav collapse" id="parent-' + val.Guid + '">' + createli(val.Guid, val.Children, "") + '</ul></li>';
            });
        }
        return tpl + '</ul';
    }
    function createli(pguid, data, str) {
        debugger;
        data && data.forEach(function (val) {
            str += '<li class="panel"><a style="text-indent: 10px" href="javascript:;" data-toggle="collapse" data-parent="#parent-' + pguid + '" data-url="' + val.Url + '" data-target="#parent-' + val.Guid + '" id="parent-a-' + val.Guid + '" class="children jumpiframe">'
                + val.JurName + '</a><ul class="nav collapse" id="parent-' + val.Guid + '">' + createli(val.Guid, val.Children, "") + '</ul></li>';
        });
        return str;
    }




});


