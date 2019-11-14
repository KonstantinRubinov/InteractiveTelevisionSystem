import { IKeyedCollection } from './IKeyedCollection';
import { Injectable } from '@angular/core';
import { LogService } from '../services/log.service';

@Injectable({
    providedIn: 'root'
  })
export class KeyedCollection<T> implements IKeyedCollection<T> {
    constructor(private logger: LogService) { }
    
    private items: { [index: string]: T } = {};
 
    private count: number = 0;
 
    public ContainsKey(key: string): boolean {
        let ifContainsKey = this.items.hasOwnProperty(key);
        this.logger.debug("KeyedCollection contains key: ", key + "=" + ifContainsKey);
        return ifContainsKey;
    }
 
    public Count(): number {
        this.logger.debug("KeyedCollection Count: ", this.count);
        return this.count;
    }
 
    public Add(key: string, value: T) {
        if(!this.items.hasOwnProperty(key)){
            this.count++;
        }
        this.items[key] = value;
        this.logger.debug("KeyedCollection Add: ", value + " add by key " + key);
    }
 
    public Remove(key: string): T {
        var val = this.items[key];
        delete this.items[key];
        this.logger.debug("KeyedCollection Remove: ", key);
        this.count--;
        return val;
    }
 
    public Item(key: string): T {
        this.logger.debug("Item: ", key);
        return this.items[key];
    }
 
    public Keys(): string[] {
        var keySet: string[] = [];
 
        for (var prop in this.items) {
            if (this.items.hasOwnProperty(prop)) {
                keySet.push(prop);
            }
        }
        this.logger.debug("Keys: ", keySet);
        return keySet;
    }
 
    public Values(): T[] {
        var values: T[] = [];
 
        for (var prop in this.items) {
            if (this.items.hasOwnProperty(prop)) {
                values.push(this.items[prop]);
            }
        }
        this.logger.debug("Values: ", values);
        return values;
    }
}