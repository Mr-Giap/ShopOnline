var billController = function () {
    var loading = false;
    this.Initialize = function () {
        if (loading == false) {
            loading = true;
            InitClick();
        } else {
            return false;
        }
        LoadData();
    }

    function InitClick() {
        //Init validation
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtStatusM: { required: true },
                txtParentIdM: { required: true },
                txtDisplayOrderM: { required: true }
            },
            messages: {
                txtNameM: {
                    required: "Tên không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                },
                txtNameAsciiM: {
                    required: "Tên không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                },
                txtParentIdM: {
                    required: "Tên định danh không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                    //number: "Vui lòng nhập đúng định dạng"
                },
                txtDisplayOrderM: {
                    required: "Tên không được bổ trống",
                    number: "Vui lòng nhập đúng định dạng"
                },
                txtSeoDescriptionM: {
                    required: "Sự nhiêu tả không được bổ trống",
                    noSpace: "Nhập  sai định dạng"
                },
                txtSeoTitleM: {
                    required: "Nội dung không được bổ trống",
                    noSpace: "Nhập  sai định dạng"
                },
                txtSeoKeyWordM: {
                    required: "Nội dung không được bổ trống",
                    noSpace: "Nhập  sai định dạng"
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
                success: function (response, data) {
                    var data = response;
                    debugger;
                    console.log(response, data);
                    $('#hidIdM').val(data.data.id);
                    var e = document.getElementById("enumPaymentsMethod");
                    var value = e.options[e.selectedIndex].value;
                    $('#ckIsShowM').prop('checked', data.data.status === 1);
                    $('#modal-add-edit').modal('show');
                    contansconfigs.stopLoading();
                },
                error: function () {
                    toastr.error('Đã có lỗi xảy ra');
                    //contansconfigs.notify('Có lỗi xảy ra', 'error');
                    contansconfigs.stopLoading();
                }
            });
        });

        $('#btnSaveM').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = $('#hidIdM').val();
                var name = $('#txtNameM').val();
                var nameAscii = $('#txtNameAsciiM').val();
                var parentId = $('#txtParentIdM').val();
                var displayOrder = $('#txtDisplayOrderM').val();
                var seoDescription = $('#txtSeoDescriptionM').val();
                var seoTitle = $('#txtSeoTitleM').val();
                var seoKeyWor = $('#txtSeoKeyWordM').val();
                var isshow = $('#ckIsShowM').prop('checked') === true ? 1 : 0;
                var url = "";
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
                        NameAscii: nameAscii,
                        ParentId: parentId,
                        DisplayOrder: displayOrder,
                        SeoDescription: seoDescription,
                        SeoTitle: seoTitle,
                        SeoKeyWord: seoKeyWor,
                        IsShow: isshow,
                    },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function (responds) {
                        if (parseInt(id) == 0) {
                            // contansconfigs.notify('Add page successful', 'success');
                            toastr.success('Add page successful');
                            $('#modal-add-edit').modal('hide');
                            //resetFormMaintainance();
                        }
                        else {
                            toastr.success('Update page successful');
                            //  contansconfigs.notify('Update page successful', 'success');
                            $('#modal-add-edit').modal('hide');
                            //resetFormMaintainance();
                        }
                        contansconfigs.stopLoading();
                        LoadData(true);
                    },
                    error: function (rp, mess, status) {
                        toastr.error('Have an error in progress');
                        // contansconfigs.notify('Have an error in progress', 'error');
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
                    type: "DELETE",
                    url: "/category/remove",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function (responds) {
                        //contansconfigs.notify('Delete page successful', 'success');
                        toastr.success('Delete page successful');
                        contansconfigs.stopLoading();
                        LoadData();
                    },
                    error: function (rp, mess, status) {
                        //contansconfigs.notify('Have an error in progress', 'error');
                        toastr.error('Have an error in progress');
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
                            UserId: item.name,
                            Status: item.parentId,
                            PaymentsMethod: item.parentId
                        });
                    });
                    //$("#lbl-total-records").text(response.rowCount); // tổng số bản ghi 
                    $("#lblTotalRecords").text(response.rowCount);

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
                toastr.error('Đã có lỗi xảy ra');
                // contansconfigs.notify("Đã có lỗi xảy ra", "danger");
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
    // 
    $("#ddlShowPage").on('change', function () {
        contansconfigs.configs.pageSize = $(this).val();
        contansconfigs.configs.pageIndex = 1;
        LoadData(true);
    });
}