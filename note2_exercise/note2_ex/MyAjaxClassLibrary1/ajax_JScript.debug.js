alert('debug');
function Add(arg1, arg2) {

    if (typeof (arg1) === 'undefined' || typeof (arg2) === 'undefined') {
        //throw Error.argumentUndefined('參數未定義');
        //上述筆記所寫的，並沒有被成功Alert出來。下方卻可以。
        return ('參數未定義');
    }

    if (arg1 === null || arg2 === null) {
        //throw Error.argumentNull('參數為Null');
        return ('參數為Null');
    }

    return arg1 + arg2 + 100;

}