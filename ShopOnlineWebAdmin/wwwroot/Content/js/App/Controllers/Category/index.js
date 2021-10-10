var categoryController = function () {
    this.Initialize = function () {
        InitClick();
        LoadData();
    }

    function InitClick() {
        //Init validation
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtNameM: { required: true },
                txtParentIdM: { required: true },
                txtSeoDescriptionM: { require: true },
                txtSeoTitleM: { require: true },
                txtSeoKeyWordM: { require: true },
            },
            messages: {
                txtNameM: {
                    required: "Tên không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                },
                txtParentIdM: {
                    required: "Tên định danh không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                    //number: "Vui lòng nhập đúng định dạng"
                },
                txtDescriptionM: {
                    required: "Sự nhiêu tả không được bổ trống",
                    noSpace: "Nhập sai định dạng"
                },
                txtSeoTitleM: {
                    required: "ội dung không được bổ trống",
                    noSpace: "Nhập sai định dạng"
                },
                txtSeoKeyWordM: {
                    required: "Nội dung không được bổ trống",
                    noSpace: "Nhập sai định dạng"
                },
            }
        });

        $("#btn-create").on('click', function () {
            //resetFormMaintainance();
            $('#modal-add-edit').modal('show');

        });
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            console.log(that);
            $.ajax({
                type: "GET",
                url: "/category/getbyid",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    contansconfigs.startLoading();
                },
                success: function (response,data) {
                    var data = response;
                    debugger;
                    console.log(response, data);
                    $('#hidIdM').val(data.data.id);
                    $('#txtNameM').val(data.data.name);
                    $('#txtParentIdM').val(data.data.parentId);
                    $('#txtSeoDescriptionM').val(data.data.seoDescription);
                    $('#txtSeoTitleM').val(data.data.seoTitle);
                    $('#txtSeoKeyWordM').val(data.data.seoKeyWord);
                    $('#ckIsShowM').prop('checked', data.data.status === 1);
                    $('#modal-add-edit').modal('show');
                    contansconfigs.stopLoading();
                },
                error: function () {
                    contansconfigs.notify('Có lỗi xảy ra', 'error');
                    contansconfigs.stopLoading();
                }
            });
        });

        $('#btnSaveM').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = $('#hidIdM').val();
                var name = $('#txtNameM').val();
                var parentId = $('#txtParentIdM').val();
                var seoDescription = $('#txtSeoDescriptionM').val();
                var seoTitle = $('#txtSeoTitleM').val();
                var seoKeyWor = $('#txtSeoKeyWordM').val();

                var isshow = $('#ckIsShowM').prop('checked') === true ? 1 : 0;
                var url = "";
                debugger;
                if (parseInt(id) == 0) {
                    url = "/category/add";
                }
                else {
                    url = "/category/update";
                }
                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        Id: id,
                        Name: name,
                        ParentId: parentId,
                        SeoDescription: seoDescription,
                        SeoTitle: seoTitle,
                        SeoKeyWord: seoKeyWor,
                        IsShow: isshow,
                    },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function () {
                        if (parseInt(id) == 0) {
                            contansconfigs.notify('Add page successful', 'success');
                            $('#modal-add-edit').modal('hide');
                            //resetFormMaintainance();
                        }
                        else {
                            contansconfigs.notify('Update page successful', 'success');
                            $('#modal-add-edit').modal('hide');
                            //resetFormMaintainance();
                        }
                        contansconfigs.stopLoading();
                        LoadData(true);
                    },
                    error: function () {

                        contansconfigs.notify('Have an error in progress', 'error');
                        contansconfigs.stopLoading();
                    }
                });
                return false;
            }
            return false;
        });

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            contansconfigs.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/category/remove",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function () {
                        contansconfigs.notify('Delete page successful', 'success');
                        contansconfigs.stopLoading();
                        LoadData();
                    },
                    error: function () {
                        contansconfigs.notify('Have an error in progress', 'error');
                        contansconfigs.stopLoading();
                    }
                });
            });
        });
    }
    function LoadData(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/category/getallpagging",
            data: {
                keyword: $('#txt-search-keyword').val(),
                page: contansconfigs.configs.pageIndex,
                pageSize: contansconfigs.configs.pageSize
            },
            dataType: "json",
            beforeSend: function () {
                contansconfigs.startLoading();
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                if (response.rowCount > 0) {
                    $.each(response.results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.id,
                            Name: item.name,
                            ParentId: item.parentId,
                            IsShow: contansconfigs.getStatus(item.isShow)
                        });
                    });
                    $("#lbl-total-records").text(response.rowCount); // phân trang

                    if (render != undefined) {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(response.rowCount, function () {
                        LoadData();
                    }, isPageChanged);


                }
                else {
                    $('#tbl-content').html('');
                }
                contansconfigs.stopLoading();
            },
            error: function (status) {
                console.log(status);
                contansconfigs.notify("Đã có lỗi xảy ra", "danger");
            }
        });
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / contansconfigs.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                contansconfigs.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}