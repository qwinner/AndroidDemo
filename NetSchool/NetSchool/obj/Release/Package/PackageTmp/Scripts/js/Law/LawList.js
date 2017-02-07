﻿$(document).ready(function () {
    doReady();
    BindSearch();
    Operation();
    BindChkAll();
    GetList(1);

    function doReady() {
        $(".LawOperation").on("click", ".addLawBtn", function () {
            var id = '00000000-0000-0000-0000-000000000000';
            showDialog(1000, 680, "http://" + window.location.host + "/Law/LawManage/" + id, function () { GetList(1) });
        }).on("click", ".delLawBtn", function () {
            var chkList = $('input:checkbox[name=chkn]:checked');
            if (chkList.length == 0) {
                alert("您没有选择需要删除的内容，请检后操作");
            }
            else {
                var allId = "";
                chkList.each(function () {
                    allId += $(this).attr("id") + ",";
                });
                allId = allId.substring(0, allId.length - 1);
                DeleteList(allId);
            }
        });
    }
    
    function DeleteList(allId) {
        var url = "http://" + window.location.host + "/Ajax/LawManage.ashx";
        var postdata = { cmd: "deleteLaw", id: allId };
        $.post(url, postdata, function (responseData) {
            if (responseData.state == "success") {
                var data = responseData.data;
                GetList(1);
            }
            else if (responseData.state == "nologin") {
                noLogin();
            }
            else {
                alert(responseData.msg);
            }
        }, "json");
    }

    function Operation() {
        $(".tbody_lawList").on("click", ".lawShow", function () {
            var id = $(this).parent().parent().find(".chk").attr("id");
            window.open("http://" + window.location.host + "/Law/LawShow/" + id);
        }).on("click", ".lawEdit", function () {
            var id = $(this).parent().parent().find(".chk").attr("id");
            showDialog(1000, 680, "http://" + window.location.host + "/Law/LawManage/" + id);
        });
    }

    function BindSearch() {
        $(".searchButton").on("click", function () {
            var strSearch = $(".searchTxt").val();
            $(".paginControl").children().remove();
            $("#hdnSearch").attr("value", strSearch);
            GetList(1);
        });
        $(".searchTxt").keydown(function (event) {
            event = window.event || event;
            var keyCode = 0;
            if (event.which) {
                keyCode = event.which;
            }
            else {
                keyCode = event.keyCode;
            }
            if (keyCode == 13) {
                var strSearch = $(this).val();
                $("#hdnSearch").val(strSearch);
                GetList(1);
            }
        });
    }

    function GetList(pageIndex) {
        var searchTxt = $("#hdnSearch").attr("value");
        var url = "http://" + window.location.host + "/Ajax/LawManage.ashx";
        var postdata = { cmd: "getList", pagesize: $("#hdnPageSize").val(), pageindex: pageIndex, strSearch: searchTxt };
        $.post(url, postdata, function (jsonData) {
            if (jsonData.state == "success") {
                dataList = jsonData.list;
                $("#hdnCount").attr("value", jsonData.count);
                var addItem = ""
                var i = 0;  
                $(dataList).each(function () {
                    var trItem = '<tr class="' + (i % 2 == 0 ? "odd-row" : "even-row") + '">'
                        +'<td><input type="checkbox" id="' + $(this)[0].LawID + '" name="chkn" class="chk" /></td>'
                        +'<td>'+(i+1)+'</td>'
                        + '<td><a class="lawShow aOperation">' + $(this)[0].Title + '</a></td>'
                        + '<td>' + $(this)[0].Author + '</td>'
                        + '<td>' + $(this)[0].EditTime.split(" ")[0] + '<br/>' + $(this)[0].CreateTime.split(" ")[1] + '</td>'
                        +'<td>'+$(this)[0].ViewNum+'</td>'
                        + '<td><a class="lawEdit aOperation">编辑</a></td></tr>'
                    addItem += trItem;
                    i++;
                });
                $(".tbody_lawList").children().remove();
                $(".tbody_lawList").prepend(addItem);
                $(".chk-all").removeAttr("checked");
                AddPagin(pageIndex);
            }
            else if (jsonData.state == "nologin") {
                noLogin();
            }
            else {
                alert(jsonData.msg);
            }
        }, "json");
    }

    function AddPagin(pageIndex) {
        pager = $("#Pagin").paginControl({
            pageIndex: pageIndex, pageSize: $("#hdnPageSize").attr("value"), recordCount: $("#hdnCount").attr("value"), onPageChanged: function (num, thisPaginControl) {
                GetList(num);
                $('html, body').animate({ scrollTop: 0 }, 'slow');
            }
        });
    }

    function BindChkAll() {
        $(document).on("click", ".chk-all", function () {
            var checked = this.checked;
            $(".LawList").find("tbody :checkbox").each(function () {
                this.checked = checked;
            });
        })
        $(".LawList").on("click", ".chk", function () {
            $(".chk-all").removeAttr("checked");
        });
    }
});