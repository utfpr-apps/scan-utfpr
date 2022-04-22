import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:http/retry.dart';
import 'package:scan/models/ambientes_model.dart';

class API {
  Future<bool> hasAmbiente(String codigoSala) async {
    final client = RetryClient(http.Client());

    List<dynamic> teste;

    List<AmbienteModel> _ambientesList;
    String json;
    try {
      json = await client
          .read(Uri.parse('https://utfpr-scan.herokuapp.com/api/Ambientes'));
          teste = await jsonDecode(json);
      for (var ambiente in teste) {
        if (ambiente.codigoSala == codigoSala) {
          
          return true;
        }
      }
    } finally {
      client.close();
    }
    return false;
  }

  Future<http.Response> createAlbum(String title) {
    return http.post(
      Uri.parse('https://jsonplaceholder.typicode.com/albums'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'title': title,
      }),
    );
  }

  Future<void> teste() async {
    final client = RetryClient(http.Client());
    try {
      print(client
          .read(Uri.parse('https://utfpr-scan.herokuapp.com/api/Ambientes')));
    } finally {
      client.close();
    }
  }
}
