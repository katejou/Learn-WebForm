
function Add(arg1, arg2) {

    if (typeof (arg1) === 'undefined' || typeof (arg2) === 'undefined') {

        var errMsg = Messages.CalcError; // Message 這個值是在 AssemblyInfo 那一邊對應 資源檔 而來的。
        alert(errMsg);
        return null;

    }

    return arg1 + arg2;

}