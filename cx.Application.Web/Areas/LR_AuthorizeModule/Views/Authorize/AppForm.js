﻿/*
 * 版 本 v1.0 辰星科技开发框架(http://www.cx.cn)
 * Copyright (c) 山西辰星昇软件科技有限公司
 * 创建人：力软-前端开发组
 * 日 期：2018.06.25
 * 描 述：移动功能模块权限设置	
 */
var objectId = request('objectId');
var objectType = request('objectType');

var acceptClick;
var bootstrap = function ($, cx) {
    "use strict";

    var selectData;
    var treeData;
    var checkModuleIds = [];

    function setTreeData() {
        if (!!selectData) {
            $('#tree').lrtreeSet('setCheck', selectData);
        }
        else {
            setTimeout(setTreeData, 100);
        }
    }
  
    var page = {
        init: function () {
            page.bind();
            page.initData();
        },
        /*绑定事件和初始化控件*/
        bind: function () {
            cx.httpAsyncGet(top.$.rootUrl + '/AppManager/FunctionManager/GetCheckTree', function (res) {
                if (res.code == 200) {
                    treeData = res.data;
                    setTimeout(function () {
                        $('#tree').lrtree({
                            data: treeData
                        });
                        if (!!objectId) {
                            setTreeData();
                        }
                    }, 10);
                }
            });
        },
        /*初始化数据*/
        initData: function () {
            if (!!objectId) {
                $.lrSetForm(top.$.rootUrl + '/LR_AuthorizeModule/Authorize/GetAppFormData?objectId=' + objectId, function (data) {//
                    selectData = data;
                });
            }
        },
        /*保存数据*/
        save: function () {
           
        }
    };

    acceptClick = function (callBack) {
        var list = [];
        var checkFormIds = $('#tree').lrtreeSet('getCheckNodeIds');
        $.each(checkFormIds, function (id, item) {
            if (item.indexOf('_LRDataItem') == -1) {
                list.push(item);
            }
        });


        var postData = {
            objectId: objectId,
            objectType: objectType,
            strFormId: String(list),
        };

        $.lrSaveForm(top.$.rootUrl + '/LR_AuthorizeModule/Authorize/SaveAppForm', postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };

    page.init();
}