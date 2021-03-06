﻿/*
 * 版 本 v1.0 辰星科技开发框架(http://www.cx.cn)
 * Copyright (c) 山西辰星昇软件科技有限公司
 * 创建人：力软-前端开发组
 * 日 期：2018.04.17
 * 描 述：发布表单功能	
 */
var refreshGirdData; // 更新数据
var bootstrap = function ($, cx) {
    "use strict";
    var page = {
        init: function () {
            page.initGrid();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                cx.layerForm({
                    id: 'Form',
                    title: '发布表单功能',
                    url: top.$.rootUrl + '/LR_FormModule/FormRelation/Form',
                    width: 700,
                    height: 500,
                    btn: null
                });
            });


            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (cx.checkrow(keyValue)) {
                    cx.layerForm({
                        id: 'Form',
                        title: '编辑表单功能',
                        url: top.$.rootUrl + '/LR_FormModule/FormRelation/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 500,
                        btn: null
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Id');
                if (cx.checkrow(keyValue)) {
                    cx.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            cx.deleteForm(top.$.rootUrl + '/LR_FormModule/FormRelation/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

        },
        initGrid: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_FormModule/FormRelation/GetPageList',
                headData: [
                    { label: "表单名称", name: "F_FormId", width: 250, align: "left" },
                    { label: "功能名称", name: "F_ModuleId", width: 250, align: "left" },
                    {
                        label: "编辑人", name: "F_CreateUserName", width: 150, align: "center",
                        formatter: function (cellvalue, row) {
                            return !!row.F_ModifyUserName ? row.F_ModifyUserName : cellvalue;
                        }
                    },
                    {
                        label: "编辑时间", name: "F_CreateDate", width: 150, align: "left",
                        formatter: function (cellvalue, row) {
                            var datetime = !!row.F_ModifyUserName ? row.F_ModifyDate : cellvalue;
                            return cx.formatDate(datetime, 'yyyy-MM-dd hh:mm');
                        }
                    }
                ],
                mainId: 'F_Id',
                reloadSelected: true,
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', param);
        }
    };

    // 保存数据后回调刷新
    refreshGirdData = function () {
        page.search();
    }

    page.init();
}