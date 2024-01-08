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

    $scope.SearchDisposal = function () {
        var Name = $scope.DisposalSearchOption.Name;
        var Email = $scope.DisposalSearchOption.Email;
        var PhoneNumber = $scope.DisposalSearchOption.MobileNo;

        $http({
            method: 'GET',
            url: '/Home/Getdata',
            params: { Name: Name, Email: Email, PhoneNumber: PhoneNumber }
        }).then(function (response) {
            debugger;
            $scope.record = response.data;
        }, function (error) {
            alert('Failed');
        });
    };

    $http({
        method: 'GET',
        url: '/Home/Getdata',
        params: { Name: '', Email: '', PhoneNumber: '' }
    }).then(function (response) {
        debugger;
        $scope.record = response.data;
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


    $scope.loadrecord = function (id) {

        $http.get("/Home/Get_databyid?id=" + id).then(function (d) {

            $scope.register = d.data[0];

        }, function (error) {

            alert('Failed');

        });

    };


    $scope.updatedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Home/update_record',

            data: $scope.register

        }).success(function (d) {

            $scope.btntext = "Update";

            $scope.register = null;

            alert(d);

        }).error(function () {

            alert('Failed');

        });

    };

    $scope.confirmDelete = function (userId) {
        var confirmation = confirm("Are you sure you want to delete this record?");

        if (confirmation) {
            $http.get("/Home/delete_record?id=" + userId)
                .then(function (response) {
                    // Handle success
                    $scope.register = response.data[0];
                })
                .catch(function (error) {
                    // Handle error
                    console.error('Error:', error);
                    alert('Failed to delete record');
                });
        } else {
            $location.path("/Home").search({ id: userId });
        }
    };
});

 



