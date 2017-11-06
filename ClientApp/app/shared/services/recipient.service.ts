import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class RecipientService {
    constructor(protected client: HttpClient) {

    }

    public register(options: { recipient: any }) {
        return this.client.post("", options.recipient);
    }
}
