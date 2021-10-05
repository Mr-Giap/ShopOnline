var productController = function () {
    this.Initialize = function () {
        InitClick();
        LoadData();
    }
    var totalSp = '';
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
        });
        //edit
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            //console.log(that);
            $.ajax({
                type: "GET",
                url: "/product/findbyid",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    contansconfigs.startLoading();
                },
                success: function (response) {
                    var data = response.data;
                    console.log(data.id);

                    $('#hidIdM').val(data.id);
                    $('#txtNameM').val(data.name);
                    $('#txtNameAsciiM').val(data.nameAscii);
                    $('#txtPriceM').val(data.price);
                    $('#txtPricePromotionM').val(data.pricPromotion);
                    $('#txtAmountM').val(data.amount);
                    $('#txtOderM').val(data.displayOrder);                    
                    $('#txtDescriptionM').val(data.description);
                    $('#txtSeoDescriptionM').val(data.seoDescription);
                    $('#txtSeoTitleM').val(data.seoTitle);
                    $('#txtSeoKeyWordM').val(data.seoKeyWord);
                     $('#ckStatusM').prop('checked', data.isShow == 1);
                    

                    $('#modal-add-edit').modal('show');
                    contansconfigs.stopLoading();

                },
                error: function (rp, mess, status) {
                    contansconfigs.notify('Có lỗi xảy ra', 'error');
                    contansconfigs.stopLoading();
                }
            });
        });
        //save
        $('#btnSaveM').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = $('#hidIdM').val();
                var name = $('#txtNameM').val();
                var seoAlias = $('#txtNameAsciiM').val();
                var price = $('#txtPriceM').val();
                var pricPromotion =  $('#txtPricePromotionM').val();
                var amount =  $('#txtAmountM').val();
                var displayOrder =  $('#txtOderM').val();
                var description =  $('#txtDescriptionM').val();
                var seoDescription =  $('#txtSeoDescriptionM').val();
                var seoTitle =  $('#txtSeoTitleM').val();
                var seoKeyWord =  $('#txtSeoKeyWordM').val();
               // var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var status = $('#ckStatusM').prop('checked') == true ? true : false;

                console.log(status);
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
                        PricPromotion: pricPromotion,
                        Amount: amount,
                        DisplayOrder: displayOrder,
                        SeoDescription: seoDescription,
                        Description: description,
                        SeoTitle: seoTitle,
                        seoKeyWord: seoKeyWord,
                        IsShow: status

                    },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function (responds) {
                        if (parseInt(id) == 0) {
                            contansconfigs.notify('add successful', 'success');
                        }
                        else {
                            contansconfigs.notify('Update page successful', 'success');
                        }

                     //   contansconfigs.notify('Update page successful', 'success');
                        $('#modal-add-edit').modal('hide');
                        //resetFormMaintainance();

                        contansconfigs.stopLoading();
                       // LoadData(true);
                        LoadData();
                     //   wrapPaging();

                    },
                    error: function (rp,mess,status) {
                        contansconfigs.notify('Have an error in progress', 'error');
                        contansconfigs.stopLoading();
                    }
                });
                return false;
            }
            return false;
        });
        //delete
        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            console.log(that);
            contansconfigs.confirm('Bạn có muốn xóa sản phẩm?', function () {
                $.ajax({
                    type: "POST",
                    url: "/product/remove",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        contansconfigs.startLoading();
                    },
                    success: function () {
                        contansconfigs.notify('Delete record successful', 'success');
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
        //search
        $(".txt-search").keyup(function () {
            //var value = $(".txt-search").val().length;
           // console.log(totalSp);
            LoadData();
            //wrapPaging(totalSp, function () {
            //    LoadData();
            //});
        });
    }
    function LoadData(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/product/getallpagging",
            data: {
                keyword: $('.txt-search').val(),
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
                totalSp = response.rowCount;
                if (response.rowCount > 0) {
                    $.each(response.results, function (i, item) {
                        render += Mustache.render(template, {
                            Name: item.name,
                            Price: item.price,
                            Amount: item.amount,
                            Id: item.id,
                            Status: contansconfigs.getStatus(item.isShow)
                        });
                    });
                    $("#lbl-total-records").text(response.rowCount);
                    if (render != undefined) {
                        $('#tbl-content').html(render);

                    }
                    wrapPaging(response.rowCount, function () {
                        LoadData();
                    }, isPageChanged);


                }
                else {
                    var keywordCount = $(".txt-search").val().length;
                    var result = '';
                    if (keywordCount >0) {
                        result = $("<tr><td></td></tr>").text("Không tìm thấy kết quả").css({ "color": "yellow", "font-size": "200%" });
                    }
                    else {
                        result = '';
                    }                    
                    $('#tbl-content').html(result);
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