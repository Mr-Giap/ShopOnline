var productController = function () {
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
                txtAliasM: { required: true }
            }
        });

        $("#btn-create").on('click', function () {
            //resetFormMaintainance();
            $('#modal-add-edit').modal('show');
            console.log("123");

        });
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/product/findbyid",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    contansconfigs.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    $('#txtPriceM').val(data.Price);
                    $('#txtNameAsciiM').val(data.NameAscii);

                    $('#ckStatusM').prop('checked', data.Status === 1);

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
                var price = $('#txtPriceM').val();
                var seoAlias = $('#txtNameAciiM').val();
                var status = $('#ckStatusM').prop('checked') === true ? 1 : 0;
                var url = "";
                if (parseInt(id) == 0) {
                    url = "/product/add";
                }
                else {
                    url = "/product/update";
                }
                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        Id: id,
                        Name: name,
                        NameAscii: seoAlias,
                        Status: status,
                        Price: price
                    },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function () {

                        contansconfigs.notify('Update page successful', 'success');
                        $('#modal-add-edit').modal('hide');
                        //resetFormMaintainance();

                        contansconfigs.stopLoading();
                        loadData(true);
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
                    url: "/product/remove",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function () {
                        contansconfigs.notify('Delete page successful', 'success');
                        contansconfigs.stopLoading();
                        loadData();
                    },
                    error: function () {
                        contansconfigs.notify('Have an error in progress', 'error');
                        contansconfigs.stopLoading();
                    }
                });
            });
        });
    }
    function LoadData() {
        $.ajax({
            type: "GET",
            url: "/product/getallpagging",
            data: {
                keyword: $('#txt-search-keyword').val(),
                pageIndex: contansconfigs.configs.pageIndex,
                pageSize: contansconfigs.configs.pageSize
            },
            dataType: "json",
            beforeSend: function () {
                contansconfigs.startLoading();
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                if (response.RowCount > 0) {
                    $.each(response.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Name: item.Name,
                            Price: item.Price,
                            Amount: item.Amount,
                            Id: item.Id,
                            Status: contansconfigs.getStatus(item.Status)
                        });
                    });
                    //$("#lbl-total-records").text(response.RowCount);
                    if (render != undefined) {
                        $('#tbl-content').html(render);

                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
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
}