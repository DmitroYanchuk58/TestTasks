'use strict';

let sudokuArray = [
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]
];
console.log(IsSudoku(sudokuArray));


function IsSudoku(board) {
    function isValidSet(set) {
        let setObj = new Set(set);
        return setObj.size === 9 && !setObj.has(0);
    }

    if(board[0].length!==9){
        return false;
    }

    for (let i = 0; i < board.length; i++) {
        if (board[i].length!==9) {
            return false;
        }
    }


    for (let i = 0; i < board.size; i++) {
        const column = [];
        for (let j = 0; j < 9; j++) {
            column.push(board[j][i]);
        }
        if (!isValidSet(column)) {
            return false;
        }
    }

    for (let row = 0; row < 9; row += 3) {
        for (let column = 0; column < 9; column += 3) {
            const block = [];
            for (let i = 0; i < 3; i++) {
                for (let j = 0; j < 3; j++) {
                    block.push(board[row + i][column + j]);
                }
            }
            if (!isValidSet(block)) {
                return false;
            }
        }
    }

    return true;
}
