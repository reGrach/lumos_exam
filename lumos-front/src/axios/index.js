import axios from 'axios'

const instance = axios.create({
    baseURL: 'http://127.0.0.1:5000/api',
    // baseURL: 'http://130.193.36.217:8080/api',
    timeout: 10000
});

// export function changeToken(token) {
//     instance.defaults.headers.common['Authorization'] = token;
// }

export function getFuture() {
    return instance.get('/exam/getfuture')
}

export function getPassed() {
    return instance.get('/exam/getpassed')
}

export function updateStatus(idQuest, val, status) {
    const data = { questionId: idQuest, value: val, Status: status };
    return instance.post('/question/updatestatus', data)
}
