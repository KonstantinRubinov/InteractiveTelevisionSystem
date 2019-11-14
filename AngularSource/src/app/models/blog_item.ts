export class BlogItem {
    constructor(
        public id?: string,
        public date?: number ,
        public title?: string,
        //public underTitle?: string,
        public comment?: string,
        public url?: string,
        public posted?:string,
        public commentsNum?: string
        ) { }
}