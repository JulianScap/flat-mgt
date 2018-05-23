import { Injectable } from "@angular/core";
import { IPassword } from "../entities/password";
import * as forge from "node-forge";
//import * as crypto from "crypto";

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

  preparePassword(password: string): IPassword {
    let result: IPassword;
    
    let salt: string = "";//crypto.randomBytes(256).toString('hex');

    let hash: string = this.getPasswordHash(password + salt);
    let encryptedHash = this.encrypt(hash);
    let base64EncryptedHash = forge.util.encode64(encryptedHash);

    result = {
      hash: base64EncryptedHash,
      salt: salt
    };

    return result;
  }
}
