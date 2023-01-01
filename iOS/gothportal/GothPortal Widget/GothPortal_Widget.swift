//
//  GothPortal_Widget.swift
//  GothPortal Widget
//
//  Created by Ethan Duke on 12/22/22.
//

import WidgetKit
import SwiftUI

struct Provider: TimelineProvider {
    func placeholder(in context: Context) -> SimpleEntry {
        SimpleEntry(date: Date(), gothImage: UIImage())
    }

    func getSnapshot(in context: Context, completion: @escaping (SimpleEntry) -> ()) {
        let entry = SimpleEntry(date: Date(), gothImage: UIImage())
        completion(entry)
    }

    func getTimeline(in context: Context, completion: @escaping (Timeline<Entry>) -> ()) {
        var entries: [SimpleEntry] = []

        // Generate a timeline consisting of five entries an hour apart, starting from the current date.
        let currentDate = Date()
        for hourOffset in 0 ..< 5 {
            let entryDate = Calendar.current.date(byAdding: .hour, value: hourOffset, to: currentDate)!
            let entry = SimpleEntry(date: entryDate, gothImage: UIImage())
            entries.append(entry)
        }

        let timeline = Timeline(entries: entries, policy: .atEnd)
        completion(timeline)
    }
}

struct SimpleEntry: TimelineEntry {
    let date: Date
    let gothImage: UIImage
}

struct GothPortal_WidgetEntryView : View {
    var entry: Provider.Entry

    var body: some View {
        gothPortalWidgetView(gothImage: entry.gothImage)
    }
}

struct GothPortal_Widget: Widget {
    let kind: String = "GothPortal_Widget"

    var body: some WidgetConfiguration {
        StaticConfiguration(kind: kind, provider: Provider()) { entry in
            GothPortal_WidgetEntryView(entry: entry)
        }
        .configurationDisplayName("gothportal")
        .description("gothportal")
    }
}

struct GothPortal_Widget_Previews: PreviewProvider {
    static var previews: some View {
        GothPortal_WidgetEntryView(entry: SimpleEntry(date: Date(), gothImage: UIImage()))
            .previewContext(WidgetPreviewContext(family: .systemSmall))
    }
}
