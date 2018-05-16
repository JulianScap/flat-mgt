import { Injectable } from "@angular/core";

import forge = require("node-forge");

@Injectable()
export class CryptoService {
    private pubAsString: string =
        `-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDKkB924j+3QyeNHLCDncvFEmil
PrVJisR5QdoQLN+X2xW31gnhb+7OlOXuecK2uo2SI9mdYLvqEikX3wPXBZSt/fDl
AkZVnlG3ayMqOF0Puy05QnSGMpPObPerh0rRFtcuRl0z9NVIrmZ1yvl4e+eMpLNX
KnOHBJFwNqcSn/cZvQIDAQAB
-----END PUBLIC KEY-----
`;

    getPasswordHash(password: string): string {
        let sha1: forge.md.MessageDigest = forge.md.sha1.create();
        sha1.update(password);
        return sha1.digest().toHex();
    }

    encrypt(text: string): string {
        let pub = forge.pki.publicKeyFromPem(this.pubAsString);
        return pub.encrypt(text);
    }

    preparePassword(password: string, date: Date): string {
        let hash: string = this.getPasswordHash(password);
        let result: string = this.encrypt(hash);

        return forge.util.encode64(result);
    }
}
