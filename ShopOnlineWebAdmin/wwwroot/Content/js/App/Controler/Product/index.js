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
                txtNameAsciiM: { required: true },
                txtPriceM: { require: true },
                txtPricePromotionM: { require: true },
                txtAmountM: { require: true },
                //txtOderM: { require: true },
                txtDescriptionM: { require: true },
                txtSeoDescriptionM: { require: true },
                txtSeoTitleM: { require: true },
                txtSeoKeyWordM: { require: true },

            },
            messages: {
                txtNameM: {
                    required: "Tên không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                },
                txtNameAsciiM: {
                    required: "Tên định danh không được bổ trống",
                    noSpace: "Nhập tên sai định dạng"
                    //number: "Vui lòng nhập đúng định dạng"
                },
                txtPriceM: {
                    required: "Tên không được bổ trống",
                    number: "Vui lòng nhập đúng định dạng"
                },
                txtPricePromotionM: {
                    required: "Giá nhập ",
                    number: "Vui lòng nhập đúng định dạng"
                },
                txtAmountM: {
                    required: "Số lượng không được bổ trống",
                    number: "Vui lòng nhập đúng định dạng"
                },
                //txtOderM: {
                //    required: "Hiển thị không được bổ trống",
                //    noSpace: "Nhập sai định dạng"
                //},
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
            $.ajax({
                type: "GET",
                url: "/product/getbyid",
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
                    $('#txtPricePromotionM').val(data.PricePromotion);
                    $('#txtAmountM').val(data.Amount);
                    //$('#txtOderM').val(data.Oder);
                    $('#txtDescriptionM').val(data.Description);
                    $('#txtSeoDescriptionM').val(data.SeoDescription);
                    $('#txtSeoTitleM').val(data.SeoTitle);
                    $('#txtSeoKeyWordM').val(data.SeoKeyWord);

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
                var seoAlias = $('#txtNameAsciiM').val();
                var pricePromotion = $('#txtPricePromotionM').val();
                var amount = $('#txtAmountM').val();
                //var oder = $('#txtOderM').val();
                var description = $('#txtDescriptionM').val();
                var seoDescription = $('#txtSeoDescriptionM').val();
                var seoTitle = $('#txtSeoTitleM').val();
                var seoKeyWor = $('#txtSeoKeyWordM').val();

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
                        Price: price,
                        PricePromotion: pricePromotion,
                        Amount: amount,
                        Description: description,
                        SeoDescription: seoDescription,
                        SeoTitle: seoTitle,
                        SeoKeyWord: seoKeyWor,
                        Status: status,
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
                    url: "/product/remove",
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
                            Id: item.Id,
                            Name: item.Name,
                            Price: item.Price,
                            Amount: item.Amount,
                            Status: contansconfigs.getStatus(item.Status)
                        });
                    });
                    //$("#lbl-total-records").text(response.RowCount); // phân trang
                    if (render != undefined) {
                        $('#tbl-content').html(render);

                    }
                    wrapPaging(response.RowCount, function () {
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
}