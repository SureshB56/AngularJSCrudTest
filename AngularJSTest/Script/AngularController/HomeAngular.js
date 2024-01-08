var app = angular.module("Homeapp", []);



app.controller("HomeController", function ($scope, $http) {

    $scope.btntext = "Save";



    $scope.savedata = function () {
        debugger;

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Home/AddUser',

            data: $scope.register

        }).success(function (d) {

            $scope.btntext = "Save";

            $scope.register = null;

            alert(d);

        }).error(function () {

            alert('Failed');

        });

    };


    $http.Get("/Home/Getdata").then(function (d) {

        $scope.record = d.data;

    }, function (error) {

        alert('Failed');

    });



    app.controller('LoginController', function ($scope, $http) {
        $scope.loginModel = {};

        $scope.login = function () {
            $http.post('/api/login', $scope.loginModel)
                .then(function (response) {
                    // Handle successful login
                    console.log(response.data);
                    // Redirect to another page if needed
                })
                .catch(function (error) {
                    // Handle login error
                    $scope.error = "Invalid Username or Password";
                    console.log(error);
                });
        };
    });
});

    // Display all record

    //$http.get("/Home/Get_data").then(function (d) {

    //    $scope.record = d.data;

    //}, function (error) {

    //    alert('Failed');

    //});

//    // Display record by id

//    $scope.loadrecord = function (id) {

//        $http.get("/Home/Get_databyid?id=" + id).then(function (d) {

//            $scope.register = d.data[0];

//        }, function (error) {

//            alert('Failed');

//        });

//    };

//    // Delete record

//    $scope.deleterecord = function (id) {

//        $http.get("/Home/delete_record?id=" + id).then(function (d) {

//            alert(d.data);

//            $http.get("/Home/Get_data").then(function (d) {

//                $scope.record = d.data;

//            }, function (error) {

//                alert('Failed');

//            });

//        }, function (error) {

//            alert('Failed');

//        });

//    };

//    // Update record

//    $scope.updatedata = function () {

//        $scope.btntext = "Please Wait..";

//        $http({

//            method: 'POST',

//            url: '/Home/update_record',

//            data: $scope.register

//        }).success(function (d) {

//            $scope.btntext = "Update";

//            $scope.register = null;

//            alert(d);

//        }).error(function () {

//            alert('Failed');

//        });

//    };

//});