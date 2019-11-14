import { NewsPrefered } from './news_prefered';

export class NewsSport extends NewsPrefered {
    constructor(
        public id: string,
        public date: number ,
        public title: string,
        public underTitle: string,
        public comment: string,
        public url: string,
        public posted:string
        ) { super(id, date, title, comment, url, posted);}
}